using DrevoDB.DBDropColumnTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBDropColumnTask;

public static class DropColumnDBTaskExtension
{
    public static IServiceCollection AddDropColumnDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<DropColumnDBTask>();
        services.AddSingleton<IDropColumnDBTaskFactory, DropColumnDBTaskFactory>();
        return services;
    }
}
