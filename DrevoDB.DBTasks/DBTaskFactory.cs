using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;
using DrevoDB.DBTasks.Tasks;

namespace DrevoDB.DBTasks;

public class DBTaskFactory : IDBTaskFactory
{
    public ISaveTableDBTask CreateSaveTableTask()
    {
        return new SaveTableDBTask();
    }

    public IDropTableDBTask CreateDropTableTask()
    {
        return new DropTableDBTask();
    }

    public ISelectDBTask CreateSelectTask()
    {
        return new SelectDBTask();
    }
}
