using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBChar;

public static class DBColumnExtension
{
    public static IServiceCollection AddDBCharColumnFactory(this IServiceCollection services)
    {
        services.AddScoped<DBCharColumn>();
        services.AddSingleton<IDBColumnFactory, DBCharColumnFactory>();
        return services;
    }
}
