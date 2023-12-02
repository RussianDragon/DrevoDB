namespace DrevoDB.DBDropTableTask.Abstractions;

public interface IDropTableDBTaskFactory
{
    IDropTableDBTask CreateTask(IServiceProvider serviceProvider);
}
