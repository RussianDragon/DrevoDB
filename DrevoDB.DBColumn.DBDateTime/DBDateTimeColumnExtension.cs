using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDateTime;

public static class DBDateTimeColumnExtension
{
    public static IServiceCollection AddDBDateTimeColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBDateTimeColumn>();
        services.AddSingleton<IDBColumnFactory, DBDateTimeColumnFactory>();
        return services;
    }
}
