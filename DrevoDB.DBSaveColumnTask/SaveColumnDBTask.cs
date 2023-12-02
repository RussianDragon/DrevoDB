using DrevoDB.Core;
using DrevoDB.DBSaveColumnTask.Abstractions;
using DrevoDB.DBTasks.Abstractions.TaskResult;

namespace DrevoDB.DBSaveColumnTask;

internal class SaveColumnDBTask : ISaveColumnDBTask
{
    public bool IsNewColumn { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;

    public EntityParameter<bool> IsNull { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsUnique { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsPrimaryKey { get; set; } = new EntityParameter<bool>();

    public IDBTaskResult Result => throw new NotImplementedException();

    public Task Execute(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Reverse()
    {
        throw new NotImplementedException();
    }
}
