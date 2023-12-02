using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Tasks;

internal class TransactionDBTask : ITransactionDBTask
{
    public ICollection<IDBTask> Tasks { get; } = new List<IDBTask>();

    public Task<IDBTaskResult> Execute()
    {
        throw new NotImplementedException();
    }
}
