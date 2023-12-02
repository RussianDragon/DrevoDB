using DrevoDB.DBSaveTableTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveTableTask;

internal class SaveTableDBTaskFactory : ISaveTableDBTaskFactory
{
    public ISaveTableDBTask CreateTask(IServiceProvider serviceProvider, SaveTableTaskParams taskParams)
    {
        var task = serviceProvider.GetRequiredService<SaveTableDBTask>();
        
        task.IsNewTable = taskParams.IsNewTable;
        task.Name = taskParams.Name;

        return task;
    }
}
