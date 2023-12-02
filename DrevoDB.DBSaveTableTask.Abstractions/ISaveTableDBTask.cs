using DrevoDB.DBTasks.Abstractions;

namespace DrevoDB.DBSaveTableTask.Abstractions;

public interface ISaveTableDBTask : IDBTask
{
    bool IsNewTable { get; }
    string Name { get; }
}
