using DrevoDB.DBDropColumnTask.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBDropColumnTask;

internal class DropColumnDBTask : IDropColumnDBTask
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
