using DrevoDB.DBTasks.Abstractions.TaskResult;
using DrevoDB.InfrastructureTypes;

namespace DrevoDB.DBTasks;

internal class DBTaskResult : IDBTaskTableResult
{
    public IReadOnlyList<Column> Columns { get; set; } = new Column[0];
    public async IAsyncEnumerable<IReadOnlyList<object>> Rows()
    {
        await Task.Delay(0);
        if (false)
        {
            yield return new object[0];
        }
    }
}
