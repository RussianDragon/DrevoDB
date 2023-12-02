using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDate;

public static class DBColumnExtension
{
    public static IServiceCollection AddDBDateColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBDateColumn>();
        services.AddSingleton<IDBColumnFactory, DBDateColumnFactory>();
        return services;
    }
}
