using DrevoDB.Core;

namespace DrevoDB.DBSaveColumnTask.Abstractions;

public class SaveColumnTaskParams
{
    public bool IsNewColumn { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;
    public EntityParameter<bool> IsNull { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsUnique { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsPrimaryKey { get; set; } = new EntityParameter<bool>();
}
