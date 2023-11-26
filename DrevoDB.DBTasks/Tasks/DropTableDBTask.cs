using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Tasks;

internal class DropTableDBTask : IDropTableDBTask
{
    public Task<IDBTaskResult> Execute()
    {
        return Task.FromResult<IDBTaskResult>(new DBTaskResult());
    }
}
