using DrevoDB.DBSaveTableTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveTableTask;

public static class SaveTableDBTaskExtension
{
    public static IServiceCollection AddSaveTableDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<SaveTableDBTask>();
        services.AddSingleton<ISaveTableDBTaskFactory, SaveTableDBTaskFactory>();
        return services;
    }
}
