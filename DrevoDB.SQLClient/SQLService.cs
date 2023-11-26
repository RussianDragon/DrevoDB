﻿using DrevoDB.Core;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;
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
            foreach (var statement in batch.Statements)
            {
                IDBTask dbTask = statement switch
                {
                    SelectStatement selectStatement => this.ParseSelect(selectStatement),
                    CreateTableStatement createTableStatement => this.ParseСreateTable(createTableStatement),
                    //CreateProcedureStatement createProcedureStatement => this.(createProcedureStatement),
                    _ => throw new ApiException(System.Net.HttpStatusCode.BadRequest, $"Not support {string.Join("", statement.ScriptTokenStream.Select(sts => sts.Text))}")
                };
                result.Add(await Convet(await dbTask.Execute(), cancellationToken));
            }
        }

        return result.ToArray();
        static async Task<Dictionary<string, object>[]> Convet(IDBTaskResult dBTaskResult, CancellationToken cancellationToken)
        {
            var result = new List<Dictionary<string, object>>();
            await foreach (var row in dBTaskResult.Rows().WithCancellation(cancellationToken))
            {
                var resultRow = new Dictionary<string, object>(dBTaskResult.Columns.Length);
                for (int i = 0; i < dBTaskResult.Columns.Length; i++)
                {
                    resultRow.Add(dBTaskResult.Columns[i].Name, row[i]);
                }
                result.Add(resultRow);
                result.Add(resultRow);
            }
            return result.ToArray();
        }
    }

    private ISaveTableDBTask ParseСreateTable(CreateTableStatement createTableStatement)
    {
        var task = this.TaskFactory.CreateSaveTableTask();

        return task;
    }

    private ISelectDBTask ParseSelect(SelectStatement selectStatement)
    {
        var task = this.TaskFactory.CreateSelectTask();

        return task;
    }
}
