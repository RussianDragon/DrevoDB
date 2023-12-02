namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskCollectionResult : IDBTaskResult
{
    IReadOnlyList<IDBTaskResult> Items { get; }
}
