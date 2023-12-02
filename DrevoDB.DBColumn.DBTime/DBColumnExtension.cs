using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBTime;

public static class DBColumnExtension
{
    public static IServiceCollection AddDBTimeColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBTimeColumn>();
        services.AddSingleton<IDBColumnFactory, DBTimeColumnFactory>();
        return services;
    }
}
