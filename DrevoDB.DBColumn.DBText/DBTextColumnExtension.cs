using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBText;

public static class DBTextColumnExtension
{
    public static IServiceCollection AddDBTextColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBTextColumn>();
        services.AddSingleton<IDBColumnFactory, DBTextColumnFactory>();
        return services;
    }
}
