using DrevoDB.DBDropTableTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBDropTableTask;

internal class DropTableDBTaskFactory : IDropTableDBTaskFactory
{
    public IDropTableDBTask CreateTask(IServiceProvider serviceProvider)
        => serviceProvider.GetRequiredService<DropTableDBTask>();
}
