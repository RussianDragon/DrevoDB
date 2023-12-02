﻿using DrevoDB.Core;
using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Tasks;

internal class SaveColumnDBTask : ISaveColumnDBTask
{
    public bool IsNewColumn { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;

    public EntityParameter<bool> IsNull { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsUnique { get; set; } = new EntityParameter<bool>();
    public EntityParameter<bool> IsPrimaryKey { get; set; } = new EntityParameter<bool>();

    public Task<IDBTaskResult> Execute()
    {
        throw new NotImplementedException();
    }
}
