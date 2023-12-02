namespace DrevoDB.DBSaveDatabaseTask.Abstractions;

public interface ISaveDatabaseDBTaskFactory
{
    ISaveDatabaseDBTask CreateTask(IServiceProvider serviceProvider, SaveDatabaseTaskParams taskParams);
}
