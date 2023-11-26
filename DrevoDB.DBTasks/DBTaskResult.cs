using DrevoDB.DBTasks.Abstractions;
using DrevoDB.InfrastructureTypes;

namespace DrevoDB.DBTasks;

internal class DBTaskResult : IDBTaskResult
{
    public Column[] Columns { get; set; } = new Column[0];
    public async IAsyncEnumerable<object[]> Rows()
    {
        await Task.Delay(0);
        if (false)
        {
            yield return new object[0];
        }
    }
}
