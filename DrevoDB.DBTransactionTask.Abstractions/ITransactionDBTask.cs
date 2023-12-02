using DrevoDB.DBTasks.Abstractions;

namespace DrevoDB.DBTransactionTask.Abstractions;

public interface ITransactionDBTask : IDBTask
{
    ICollection<IDBTask> Tasks { get; }
}
