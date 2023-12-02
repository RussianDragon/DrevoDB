using DrevoDB.DBSaveDatabaseTask.Abstractions;
using DrevoDB.DBSaveDatabaseTask.Models;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSaveDatabaseTask;

internal class SaveDatabaseDBTask : ISaveDatabaseDBTask
{
    public bool IsNewDatabase { get; set; }

    public string Name { get; set; } = string.Empty;

    IDBTaskResult IDBTask.Result => this.Result;
    public DBTaskResult Result { get; } = new DBTaskResult();

    public Task Execute(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Reverse()
    {
        throw new NotImplementedException();
    }
}
