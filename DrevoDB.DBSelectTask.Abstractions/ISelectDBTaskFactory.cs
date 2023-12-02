using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSelectTask.Abstractions;

public interface ISelectDBTaskFactory
{
    ISelectDBTask CreateTask(IServiceProvider serviceProvider);
}
