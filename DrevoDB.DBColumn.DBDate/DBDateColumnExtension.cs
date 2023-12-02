using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDate;

public static class DBDateColumnExtension
{
    public static IServiceCollection AddDBDateColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBDateColumn>();
        services.AddSingleton<IDBColumnFactory, DBDateColumnFactory>();
        return services;
    }
}
