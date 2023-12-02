using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;
using DrevoDB.DBTasks.TaskResult;

namespace DrevoDB.DBTasks.Tasks;

internal class TransactionDBTask : ITransactionDBTask
{
    public ICollection<IDBTask> Tasks { get; } = new List<IDBTask>();

    public async Task<IDBTaskResult> Execute()
    {
        var items = new List<IDBTaskResult>();


        return new DBTaskCollectionResult()
        {
            Items = items
        };
    }
}
