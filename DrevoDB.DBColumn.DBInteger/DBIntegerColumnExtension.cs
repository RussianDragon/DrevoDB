using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBInteger;

public static class DBIntegerColumnExtension
{
    public static IServiceCollection AddDBIntegerColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBIntegerColumn>();
        services.AddSingleton<IDBColumnFactory, DBIntegerColumnFactory>();
        return services;
    }
}
