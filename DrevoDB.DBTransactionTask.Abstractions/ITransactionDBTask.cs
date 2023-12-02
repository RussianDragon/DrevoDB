using DrevoDB.DBTasks.Abstractions;

namespace DrevoDB.DBTransactionTask.Abstractions;

public interface ITransactionDBTask : IDBTask
{
    IEnumerable<IDBTask> Tasks { get; }
    void AddTask(IDBTask taks);
}
