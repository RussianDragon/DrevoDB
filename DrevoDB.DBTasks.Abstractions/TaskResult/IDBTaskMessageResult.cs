namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskMessageResult : IDBTaskResult
{
    string Message { get; }
}
