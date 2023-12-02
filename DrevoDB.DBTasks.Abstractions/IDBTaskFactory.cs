using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTaskFactory
{
    ITransactionDBTask CreateTransactionTask();

    ISaveTableDBTask CreateSaveTableTask();
    IDropTableDBTask CreateDropTableTask();

    ISaveColumnDBTask CreateSaveColumnTask();
    IDropColumnDBTask CreateDropColumnTask();

    ISelectDBTask CreateSelectTask();
}
