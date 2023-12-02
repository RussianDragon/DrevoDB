using DrevoDB.DBTransactionTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBTransactionTask;

internal class TransactionDBTaskFactory: ITransactionDBTaskFactory
{
    public ITransactionDBTask CreateTask(IServiceProvider serviceProvider)
        => serviceProvider.GetRequiredService<TransactionDBTask>();
}
