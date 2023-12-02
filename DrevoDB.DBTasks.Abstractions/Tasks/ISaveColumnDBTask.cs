using DrevoDB.Core;

namespace DrevoDB.DBTasks.Abstractions.Tasks;

public interface ISaveColumnDBTask : IDBTask
{
    bool IsNewColumn { get; set; }
    string Name { get; set; }
    string TypeName { get; set; }
    EntityParameter<bool> IsNull { get; set; }
    EntityParameter<bool> IsUnique { get; set; }
    EntityParameter<bool> IsPrimaryKey { get; set; }
}
