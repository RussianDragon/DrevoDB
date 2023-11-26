using DrevoDB.Core;
using DrevoDB.InfrastructureTypes;

namespace DrevoDB.DBTasks.Abstractions.Tasks;

public interface ISaveColumnDBTask : IDBTask
{
    bool IsNewColumn { get; set; }
    string Name { get; set; }
    EntityParameter<bool> IsNull { get; set; }
    EntityParameter<bool> IsUnique { get; set; }
    EntityParameter<bool> IsPrimaryKey { get; set; }
    EntityParameter<ColumnsTypes> Type { get; set; }    
}
