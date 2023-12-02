using DrevoDB.DBSaveDatabaseTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveDatabaseTask;

internal class SaveDatabaseDBTaskFactory : ISaveDatabaseDBTaskFactory
{
    public ISaveDatabaseDBTask CreateTask(IServiceProvider serviceProvider, SaveDatabaseTaskParams taskParams)
    {
        var task = serviceProvider.GetRequiredService<SaveDatabaseDBTask>();

        task.IsNewDatabase = taskParams.IsNewDatabase;
        task.Name = taskParams.Name;

        return task;
    }
}
