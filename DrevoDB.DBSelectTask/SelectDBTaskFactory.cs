using DrevoDB.DBSelectTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSelectTask;

internal class SelectDBTaskFactory : ISelectDBTaskFactory
{
    public ISelectDBTask CreateTask(IServiceProvider serviceProvider)
        => serviceProvider.GetRequiredService<SelectDBTask>();
}
