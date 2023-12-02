using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSaveDatabaseTask.Models;

internal class DBTaskResult : IDBTaskMessageResult
{
    public string Message { get; set; } = string.Empty;
}
