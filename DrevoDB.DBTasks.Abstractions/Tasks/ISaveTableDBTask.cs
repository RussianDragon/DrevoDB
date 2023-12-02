namespace DrevoDB.DBTasks.Abstractions.Tasks;

public interface ISaveTableDBTask : IDBTask
{
    bool IsNewTable { get; set; }
    string Name { get; set; }
}
