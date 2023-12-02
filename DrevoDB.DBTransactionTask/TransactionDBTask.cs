using DrevoDB.DBTasks.Abstractions.TaskResult;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTransactionTask.Abstractions;
using DrevoDB.DBTransactionTask.Models;

namespace DrevoDB.DBTransactionTask;

internal class TransactionDBTask : ITransactionDBTask
{
    public ICollection<IDBTask> Tasks { get; } = new List<IDBTask>();
    IDBTaskResult IDBTask.Result => this.Result;
    public DBTaskResult Result { get; } = new DBTaskResult();

    private Stack<IDBTask> ExecuteTasks { get; } = new Stack<IDBTask>();
    private NLog.ILogger Logger { get; } = NLog.LogManager.GetCurrentClassLogger();

    private bool IsReversed { get; set; } = false;

    public async Task Execute(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            foreach (var task in Tasks)
            {
                this.ExecuteTasks.Push(task);
                await task.Execute(cancellationToken);
                this.Result.Items.Enqueue(task.Result);
            }
        }
        catch (Exception ex)
        {
            this.Logger.Error(ex);
            await this.Reverse();
            throw;
        }
    }

    public async Task Reverse()
    {
        if (IsReversed) return;
        IsReversed = true;

        this.Result.Items.Clear();
        while (this.ExecuteTasks.Any())
        {
            var task = this.ExecuteTasks.Pop();
            await task.Reverse();
            this.Result.Items.Enqueue(task.Result);
        }
    }
}
