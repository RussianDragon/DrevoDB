using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBTasks.Abstractions.TaskResult;

public interface IDBTaskTableResult : IDBTaskResult
{
    IEnumerable<IDBColumn> Columns { get; }
    IAsyncEnumerable<IEnumerable<object>> Rows();
}
