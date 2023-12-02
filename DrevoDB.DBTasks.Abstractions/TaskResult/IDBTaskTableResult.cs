using DrevoDB.InfrastructureTypes;

namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskTableResult : IDBTaskResult
{
    IReadOnlyList<Column> Columns { get; }
    IAsyncEnumerable<IReadOnlyList<object>> Rows();
}
