using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTaskFactory
{
    ISaveTableDBTask CreateSaveTableTask();
    IDropTableDBTask CreateDropTableTask();

    ISaveColumnDBTask CreateSaveColumnTask();
    IDropColumnDBTask CreateDropColumnTask();

    ISelectDBTask CreateSelectTask();
}
