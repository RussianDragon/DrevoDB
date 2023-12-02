using DrevoDB.DBTransactionTask.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBTransactionTask;

public static class TransactionDBTaskExtension
{
    public static IServiceCollection AddTransactionDBTaskFactory(this IServiceCollection services)
    {
        services.AddScoped<TransactionDBTask>();
        services.AddSingleton<ITransactionDBTaskFactory, TransactionDBTaskFactory>();
        return services;
    }
}
