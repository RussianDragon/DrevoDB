using DrevoDB.DBDropColumnTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBDropColumnTask;

internal class DropColumnDBTaskFactory : IDropColumnDBTaskFactory
{
    public IDropColumnDBTask CreateTask(IServiceProvider serviceProvider)
        => serviceProvider.GetRequiredService<DropColumnDBTask>();
}
