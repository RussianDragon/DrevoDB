﻿using DrevoDB.DBTasks.Abstractions;
using DrevoDB.DBTasks.Abstractions.Tasks;

namespace DrevoDB.DBTasks.Tasks;

internal class DropColumnDBTask : IDropColumnDBTask
{
    public Task<IDBTaskResult> Execute()
    {
        throw new NotImplementedException();
    }
}
