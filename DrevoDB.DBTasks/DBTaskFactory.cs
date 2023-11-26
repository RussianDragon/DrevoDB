using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;
using DrevoDB.DBTasks.Tasks;

namespace DrevoDB.DBTasks;

public class DBTaskFactory : IDBTaskFactory
{
    public ISaveTableDBTask CreateSaveTableTask() => new SaveTableDBTask();
    public IDropTableDBTask CreateDropTableTask() => new DropTableDBTask();

    public ISaveColumnDBTask CreateSaveColumnTask() => new SaveColumnDBTask();
    public IDropColumnDBTask CreateDropColumnTask() => new DropColumnDBTask();

    public ISelectDBTask CreateSelectTask() => new SelectDBTask();
}
