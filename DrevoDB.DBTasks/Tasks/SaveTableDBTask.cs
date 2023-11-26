using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Tasks;

internal class SaveTableDBTask : ISaveTableDBTask
{
    public bool IsNewTable { get; set; }
    public string Name { get; set; } = string.Empty;

    public Task<IDBTaskResult> Execute()
    {
        return Task.FromResult<IDBTaskResult>(new DBTaskResult());
    }
}
