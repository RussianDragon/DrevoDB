using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBTransactionTask.Models;

internal class DBTaskResult : IDBTaskCollectionResult
{
    IEnumerable<IDBTaskResult> IDBTaskCollectionResult.Items => this.Items;
    public Queue<IDBTaskResult> Items { get; } = new Queue<IDBTaskResult>();
    
}
