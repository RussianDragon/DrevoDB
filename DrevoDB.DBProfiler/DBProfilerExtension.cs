using DrevoDB.DBProfiler.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBProfiler;

public static class DBProfilerExtension
{
    public static IServiceCollection AddDBProfiler(this IServiceCollection services)
    {
        services.AddScoped<IProfiler, Profiler>();
        return services;
    }
}
