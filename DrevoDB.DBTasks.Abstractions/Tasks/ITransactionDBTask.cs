namespace DrevoDB.DBTasks.Abstractions.Tasks;

public interface ITransactionDBTask : IDBTask
{
    ICollection<IDBTask> Tasks { get; }
}
