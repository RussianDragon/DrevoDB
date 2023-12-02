using DrevoDB.DBColumns.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumns;

public static class DBColumnsExtension
{
    public static IServiceCollection AddDBColumnsFactory(this IServiceCollection services)
    {
        services.AddSingleton<IDBColumnsFactory, ColumnsFactory>();
        return services;
    }
}
