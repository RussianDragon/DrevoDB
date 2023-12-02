using DrevoDB.DBSelectTask.Abstractions;
using DrevoDB.DBSelectTask.Models;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSelectTask;

internal class SelectDBTask : ISelectDBTask
{
    public IDBTaskResult Result => new DBTaskResult();

    public Task Execute(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task Reverse()
    {
        return Task.CompletedTask;
    }
}
