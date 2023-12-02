using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveTableTask.Abstractions;

public interface ISaveTableDBTaskFactory
{
    ISaveTableDBTask CreateTask(IServiceProvider serviceProvider, SaveTableTaskParams taskParams);
}
