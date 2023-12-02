using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskTableResult : IDBTaskResult
{
    IReadOnlyList<IDBColumn> Columns { get; }
    IAsyncEnumerable<IReadOnlyList<object>> Rows();
}
