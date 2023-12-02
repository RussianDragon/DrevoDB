using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBTasks.TaskResult;

internal class DBTaskCollectionResult : IDBTaskCollectionResult
{
    public required IReadOnlyList<IDBTaskResult> Items { get; init; }
}
