using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBTransactionTask.Abstractions;

public interface ITransactionDBTaskFactory
{
    ITransactionDBTask CreateTask(IServiceProvider serviceProvider);
}
