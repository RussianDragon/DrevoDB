﻿namespace DrevoDB.DBSaveColumnTask.Abstractions;

public interface ISaveColumnDBTaskFactory
{
    ISaveColumnDBTask CreateTask(IServiceProvider serviceProvider, SaveColumnTaskParams taskParams);
}
