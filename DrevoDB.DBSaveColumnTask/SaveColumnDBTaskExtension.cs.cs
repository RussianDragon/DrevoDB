using DrevoDB.DBSaveColumnTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveColumnTask;

public static class SaveColumnDBTaskExtension
{
    public static IServiceCollection AddSaveColumnDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<SaveColumnDBTask>();
        services.AddSingleton<ISaveColumnDBTaskFactory, SaveColumnDBTaskFactory>();
        return services;
    }
}
