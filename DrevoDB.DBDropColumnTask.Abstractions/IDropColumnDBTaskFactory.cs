using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBDropColumnTask.Abstractions;

public interface IDropColumnDBTaskFactory
{
    IDropColumnDBTask CreateTask(IServiceProvider serviceProvider);
}
