using DrevoDB.DBTasks.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBTasks;

public static class DBTasksExtension
{
    public static IServiceCollection AddDBTasks(this IServiceCollection services)
    {
        services.AddSingleton<IDBTaskFactory, DBTaskFactory>();
        return services;
    }
}
