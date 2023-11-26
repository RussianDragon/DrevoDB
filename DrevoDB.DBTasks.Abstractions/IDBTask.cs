namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTask
{
    Task<IDBTaskResult> Execute();
}
