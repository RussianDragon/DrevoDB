using DrevoDB.DBSaveTableTask.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSaveTableTask;

internal class SaveTableDBTask : ISaveTableDBTask
{
    public bool IsNewTable { get; set; }
    public string Name { get; set; } = string.Empty;

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
