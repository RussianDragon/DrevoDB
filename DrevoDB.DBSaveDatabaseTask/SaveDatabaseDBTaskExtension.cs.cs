using DrevoDB.DBSaveDatabaseTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBSaveDatabaseTask;

public static class SaveDatabaseDBTaskExtension
{
    public static IServiceCollection AddSaveDatabaseDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<SaveDatabaseDBTask>();
        services.AddSingleton<ISaveDatabaseDBTaskFactory, SaveDatabaseDBTaskFactory>();
        return services;
    }
}
