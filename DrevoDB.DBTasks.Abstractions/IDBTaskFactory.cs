using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTaskFactory
{
    ISelectDBTask CreateSelectTask();
    ISaveTableDBTask CreateSaveTableTask();
    IDropTableDBTask CreateDropTableTask();
}
