using DrevoDB.DBSelectTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSelectTask;

public static class SelectDBTaskExtension
{
    public static IServiceCollection AddSelectDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<SelectDBTask>();
        services.AddSingleton<ISelectDBTaskFactory, SelectDBTaskFactory>();
        return services;
    }
}
