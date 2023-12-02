using DrevoDB.DBSaveColumnTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveColumnTask;

internal class SaveColumnDBTaskFactory : ISaveColumnDBTaskFactory
{
    public ISaveColumnDBTask CreateTask(IServiceProvider serviceProvider, SaveColumnTaskParams taskParams)
    {
        var task = serviceProvider.GetRequiredService<SaveColumnDBTask>();

        return task;
    }
}
