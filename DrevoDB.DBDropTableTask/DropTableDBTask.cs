using DrevoDB.DBDropTableTask.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBDropTableTask;

internal class DropTableDBTask : IDropTableDBTask
{
    public IDBTaskResult Result => throw new NotImplementedException();

    public Task Execute(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Reverse()
    {
        throw new NotImplementedException();
    }
}
