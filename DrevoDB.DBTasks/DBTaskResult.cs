using DrevoDB.DBColumn.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBTasks;

internal class DBTaskResult : IDBTaskTableResult
{
    public IReadOnlyList<IDBColumn> Columns { get; set; } = new IDBColumn[0];

    public async IAsyncEnumerable<IReadOnlyList<object>> Rows()
    {
        await Task.Delay(0);
        if (false)
        {
            yield return new object[0];
        }
    }
}
