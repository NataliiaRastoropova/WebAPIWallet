using Microsoft.Extensions.DependencyInjection;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Services;

namespace WalletAPI.BusinessLogic.Installers;

public static class TransactionInstaller
{
    public static IServiceCollection AddTransactions(this IServiceCollection services)
    {
        services
            .AddScoped<ITransactionService, TransactionService>();
        return services;
    }
}