using DrevoDB.Core;
using DrevoDB.DBColumn.Abstractions;
using DrevoDB.DBSaveDatabaseTask.Abstractions;
using DrevoDB.DBProfiler.Abstractions;
using DrevoDB.DBSaveColumnTask.Abstractions;
using DrevoDB.DBSaveTableTask.Abstractions;
using DrevoDB.DBSelectTask.Abstractions;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;
using DrevoDB.DBTransactionTask.Abstractions;
using DrevoDB.SQLClient.Models;
using DrevoDB.SQLClient.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Globalization;
using System.Text;

namespace DrevoDB.SQLClient;

internal class SQLService
{
    private IServiceProvider ServiceProvider { get; }
    private IProfiler Profiler { get; }
    private ITransactionDBTaskFactory TransactionTaskFactory { get; }
    private NLog.ILogger Logger { get; } = NLog.LogManager.GetCurrentClassLogger();

    public SQLService(IServiceProvider serviceProvider,
                      IProfiler profiler,
                      ITransactionDBTaskFactory transactionTaskFactory)
    {
        this.ServiceProvider = serviceProvider;
        this.Profiler = profiler;
        this.TransactionTaskFactory = transactionTaskFactory;
    }

    internal async Task<JsonResult> GetJson(JsonRequest request, CancellationToken cancellationToken)
    {
        this.Profiler.RequestStart(request.ProfilerIsActive);
        this.Profiler.Start(Phases.QueueParse);
        byte[] originalsQueryBytes = Encoding.UTF8.GetBytes(request.Query);
        using var rdr = new StreamReader(new MemoryStream(originalsQueryBytes));

        var parser = new TSql160Parser(true, SqlEngineType.All);
        var tree = parser.Parse(rdr, out IList<ParseError> errors) as TSqlScript;

        #region validate tree
        if (errors.Any())
        {
            StringBuilder errorMessage = new StringBuilder();
            foreach (ParseError err in errors)
            {
                errorMessage.AppendLine(err.Message);
            }
            throw new ApiException(System.Net.HttpStatusCode.InternalServerError, errorMessage.ToString());
        }
        if (tree is null)
        {
            throw new ApiException(System.Net.HttpStatusCode.InternalServerError, "Is not sql script");
        }
        #endregion


        var batches = new List<ITransactionDBTask>(tree.Batches.Count);
        foreach (var batch in tree.Batches)
        {
            var transaction = this.TransactionTaskFactory.CreateTask(this.ServiceProvider);
            batches.Add(transaction);

            foreach (var statement in batch.Statements)
            {
                switch (statement)
                {
                    case SelectStatement selectStatement:
                        {
                            this.ParseSelect(selectStatement, transaction);
                            break;
                        }
                    case CreateTableStatement createTableStatement:
                        {
                            this.ParseСreateTable(createTableStatement, transaction);
                            break;
                        }
                    //case CreateProcedureStatement createProcedureStatement:
                    //    {
                    //        this.(createProcedureStatement, tasks)
                    //                break;
                    //    }
                    case CreateDatabaseStatement createDatabaseStatement:
                        {
                            this.ParseCreateDatabaseStatement(createDatabaseStatement, transaction);
                            break;
                        }
                    default:
                        {
                            throw new ApiException(System.Net.HttpStatusCode.BadRequest, $"Not support {string.Join("", statement.ScriptTokenStream.Select(sts => sts.Text))}");
                        }
                };
            }
        }
        this.Profiler.End(Phases.QueueParse);

        var result = new List<Dictionary<string, object>[]>(batches.Count);
        foreach (var batch in batches)
        {
            try
            {
                await batch.Execute();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex);
            }

            this.Profiler.Start(Phases.TransformResult);
            result.AddRange(await Convet(batch.Result, cancellationToken));
            this.Profiler.End(Phases.TransformResult);
        }

        this.Profiler.RequestEnd();
        var profiler = this.Profiler.Result;
        return new JsonResult()
        {
            RequestElapsed = profiler.RequestElapsed,
            Profile = profiler.ElapsedPhases.ToDictionary(phase => phase.Key.ToString(), phase => phase.Value),
            ElapsedTime = profiler.Total,
            Result = result.ToArray(),
        };
        static async Task<Dictionary<string, object>[][]> Convet(IDBTaskResult dBTaskResult, CancellationToken cancellationToken)
        {
            var resultCollection = new List<Dictionary<string, object>[]>();
            await Convet(dBTaskResult: dBTaskResult,
                         resultCollection: resultCollection,
                         cancellationToken: cancellationToken);
            return resultCollection.ToArray();
            static async Task Convet(IDBTaskResult dBTaskResult,
                                     List<Dictionary<string, object>[]> resultCollection,
                                     CancellationToken cancellationToken)
            {
                switch (dBTaskResult)
                {
                    case IDBTaskMessageResult messageResult:
                        {
                            resultCollection.Add([
                                new Dictionary<string, object>() {
                                    { "Result", messageResult.Message }
                                }
                            ]);
                            break;
                        }
                    case IDBTaskTableResult tableResult:
                        {
                            var result = new List<Dictionary<string, object>>();
                            var columns = new Queue<IDBColumn>(tableResult.Columns);
                            var countColumns = columns.Count;

                            await foreach (var row in tableResult.Rows().WithCancellation(cancellationToken))
                            {
                                var resultRow = new Dictionary<string, object>(countColumns);
                                var columnIterator = columns.GetEnumerator();
                                var rowIterator = row.GetEnumerator();

                                for (int i = 0; i < countColumns; i++)
                                {
                                    resultRow.Add(columnIterator.Current.Name, rowIterator.Current);
                                    columnIterator.MoveNext();
                                    rowIterator.MoveNext();
                                }
                                result.Add(resultRow);
                            }
                            resultCollection.Add(result.ToArray());
                            break;
                        }
                    case IDBTaskCollectionResult collectionResult:
                        {
                            foreach (var item in collectionResult.Items)
                            {
                                await Convet(dBTaskResult: item,
                                             resultCollection: resultCollection,
                                             cancellationToken: cancellationToken);
                            }
                            break;
                        }
                    default:
                        {
                            throw new ApiException($"Not support result type \"{dBTaskResult.GetType()}\"");
                        }
                }
            }
        }
    }

    private void ParseSelect(SelectStatement selectStatement, ITransactionDBTask transaction)
    {
        transaction.AddTask(this.ServiceProvider.GetRequiredService<ISelectDBTaskFactory>()
                                                .CreateTask(this.ServiceProvider));
    }

    private void ParseСreateTable(CreateTableStatement createTableStatement, ITransactionDBTask transaction)
    {
        #region table settings
        var saveTableTaskParams = new SaveTableTaskParams();

        saveTableTaskParams.IsNewTable = true;
        saveTableTaskParams.Name = createTableStatement.SchemaObjectName.BaseIdentifier.Value;

        transaction.AddTask(this.ServiceProvider.GetRequiredService<ISaveTableDBTaskFactory>()
                                .CreateTask(this.ServiceProvider, saveTableTaskParams));
        #endregion

        #region column settings
        foreach (var columnDefinition in createTableStatement.Definition.ColumnDefinitions)
        {
            var taskParams = new SaveColumnTaskParams();

            taskParams.IsNewColumn = true;
            taskParams.Name = columnDefinition.ColumnIdentifier.Value;
            taskParams.TypeName = columnDefinition.DataType.Name.BaseIdentifier.Value.ToLower(CultureInfo.InvariantCulture);

            foreach (var constraint in columnDefinition.Constraints)
            {
                switch (constraint)
                {
                    case NullableConstraintDefinition nullableConstraint:
                        {
                            taskParams.IsNull = nullableConstraint.Nullable;
                            break;
                        }
                    case UniqueConstraintDefinition uniqueConstraint:
                        {
                            taskParams.IsUnique = true;
                            taskParams.IsPrimaryKey = uniqueConstraint.IsPrimaryKey;
                            break;
                        }
                    default:
                        {
                            throw new ApiException($"Not support type \"{constraint.GetType()}\"");
                        }
                }
            }

            transaction.AddTask(this.ServiceProvider.GetRequiredService<ISaveColumnDBTaskFactory>()
                                                    .CreateTask(this.ServiceProvider, taskParams));
        }
        #endregion
    }

    private void ParseCreateDatabaseStatement(CreateDatabaseStatement createDatabaseStatement, ITransactionDBTask transaction)
    {
        var taskParams = new SaveDatabaseTaskParams();

        taskParams.IsNewDatabase = true;
        taskParams.Name = createDatabaseStatement.DatabaseName.Value;

        transaction.AddTask(this.ServiceProvider.GetRequiredService<ISaveDatabaseDBTaskFactory>()
                                                .CreateTask(this.ServiceProvider, taskParams));
    }
}
