using DrevoDB.DBTasks.Abstractions;

namespace DrevoDB.DBSaveDatabaseTask.Abstractions;

public interface ISaveDatabaseDBTask : IDBTask
{
    bool IsNewDatabase { get;  }
    string Name { get; }
}
