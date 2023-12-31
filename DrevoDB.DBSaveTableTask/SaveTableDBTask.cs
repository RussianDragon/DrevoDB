﻿using DrevoDB.DBSaveTableTask.Abstractions;
using DrevoDB.DBSaveTableTask.Models;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSaveTableTask;

internal class SaveTableDBTask : ISaveTableDBTask
{
    public bool IsNewTable { get; set; }
    public string Name { get; set; } = string.Empty;

    IDBTaskResult IDBTask.Result => this.Result;
    public DBTaskResult Result { get; } = new DBTaskResult();


    public Task Execute(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
        //this.Result.Equals(this.Result);
    }

    public Task Reverse()
    {
        throw new NotImplementedException();
    }
}
