using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTask
{
    IDBTaskResult Result { get; }
    Task Execute(CancellationToken cancellationToken = default);
    Task Reverse();
}
