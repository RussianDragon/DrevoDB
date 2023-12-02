namespace DrevoDB.DBDropColumnTask.Abstractions;

public interface IDropColumnDBTaskFactory
{
    IDropColumnDBTask CreateTask(IServiceProvider serviceProvider);
}
