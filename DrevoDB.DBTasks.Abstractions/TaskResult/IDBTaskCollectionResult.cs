namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskCollectionResult : IDBTaskResult
{
    IEnumerable<IDBTaskResult> Items { get; }
}
