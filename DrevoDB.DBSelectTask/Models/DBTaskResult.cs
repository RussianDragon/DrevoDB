using DrevoDB.DBColumn.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSelectTask.Models;

internal class DBTaskResult : IDBTaskTableResult
{
    public IEnumerable<IDBColumn> Columns { get; set; } = new IDBColumn[0];

    public async IAsyncEnumerable<IEnumerable<object>> Rows()
    {
        await Task.Delay(0);
        if (false)
        {
            yield return new object[0];
        }
    }
}
