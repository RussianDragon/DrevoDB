using DrevoDB.DBDropTableTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBDropTableTask;

public static class DropTableDBTaskExtension
{
    public static IServiceCollection AddDropTableDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<DropTableDBTask>();
        services.AddSingleton<IDropTableDBTaskFactory, DropTableDBTaskFactory>();
        return services;
    }
}
