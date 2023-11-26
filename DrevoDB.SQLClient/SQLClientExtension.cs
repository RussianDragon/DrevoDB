using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.SQLClient;

public static class SQLClientExtension
{
    public static IServiceCollection AddSQLClient(this IServiceCollection services)
    {
        services.AddScoped<SQLService>();
        return services;
    }
}
