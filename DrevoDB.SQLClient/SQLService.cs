﻿using DrevoDB.Core;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;
using DrevoDB.DBTasks.Abstractions.Tasks;
using DrevoDB.InfrastructureTypes;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DrevoDB.SQLClient;

internal class SQLService
{
    private IDBTaskFactory TaskFactory { get; }
    public SQLService(IDBTaskFactory taskFactory)
    {
        this.TaskFactory = taskFactory;
    }

    internal async Task<Dictionary<string, object>[][]> GetJson(string query, CancellationToken cancellationToken)
    {
        byte[] originalsQueryBytes = Encoding.UTF8.GetBytes(query);
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

        var result = new List<Dictionary<string, object>[]>(tree.Batches.Count);
        foreach (var batch in tree.Batches)
        {
            var transaction = this.TaskFactory.CreateTransactionTask();
            foreach (var statement in batch.Statements)
            {
                switch (statement)
                {
                    case SelectStatement selectStatement:
                        {
                            this.ParseSelect(selectStatement, transaction.Tasks);
                            break;
                        }
                    case CreateTableStatement createTableStatement:
                        {
                            this.ParseСreateTable(createTableStatement, transaction.Tasks);
                            break;
                        }
                    //case CreateProcedureStatement createProcedureStatement:
                    //    {
                    //        this.(createProcedureStatement, tasks)
                    //                break;
                    //    }
                    default:
                        {
                            throw new ApiException(System.Net.HttpStatusCode.BadRequest, $"Not support {string.Join("", statement.ScriptTokenStream.Select(sts => sts.Text))}");
                        }
                };
            }

            result.AddRange(await Convet(await transaction.Execute(), cancellationToken));
        }

        return result.ToArray();
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
                            await foreach (var row in tableResult.Rows().WithCancellation(cancellationToken))
                            {
                                var resultRow = new Dictionary<string, object>(tableResult.Columns.Count);
                                for (int i = 0; i < tableResult.Columns.Count; i++)
                                {
                                    resultRow.Add(tableResult.Columns[i].Name, row[i]);
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

    private void ParseСreateTable(CreateTableStatement createTableStatement, ICollection<IDBTask> tasks)
    {
        #region table settings
        var task = this.TaskFactory.CreateSaveTableTask();
        tasks.Add(task);

        task.IsNewTable = true;
        task.Name = createTableStatement.SchemaObjectName.BaseIdentifier.Value;
        #endregion

        #region column settings
        foreach (var columnDefinition in createTableStatement.Definition.ColumnDefinitions)
        {
            var column = this.TaskFactory.CreateSaveColumnTask();
            tasks.Add(column);

            column.IsNewColumn = true;
            column.Name = columnDefinition.ColumnIdentifier.Value;

            var typeStr = columnDefinition.DataType.Name.BaseIdentifier.Value.ToLower(CultureInfo.InvariantCulture);
            column.Type = typeStr switch
            {
                "char" => ColumnsTypes.Char,
                "text" => ColumnsTypes.Text,

                "int" => ColumnsTypes.Integer,

                "datetime" => ColumnsTypes.DateTime,
                "date" => ColumnsTypes.Date,
                "time" => ColumnsTypes.Time,
                _ => throw new ApiException($"Not support type \"{typeStr}\"")
            };

            foreach (var constraint in columnDefinition.Constraints)
            {
                switch (constraint)
                {
                    case NullableConstraintDefinition nullableConstraint:
                        {
                            column.IsNull = nullableConstraint.Nullable;
                            break;
                        }
                    case UniqueConstraintDefinition uniqueConstraint:
                        {
                            column.IsUnique = true;
                            column.IsPrimaryKey = uniqueConstraint.IsPrimaryKey;
                            break;
                        }
                    default:
                        {
                            throw new ApiException($"Not support type \"{constraint.GetType()}\"");
                        }
                }
            }
        }
        #endregion
    }

    private ISelectDBTask ParseSelect(SelectStatement selectStatement, ICollection<IDBTask> tasks)
    {
        var task = this.TaskFactory.CreateSelectTask();

        return task;
    }
}
