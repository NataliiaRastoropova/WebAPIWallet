using Microsoft.Extensions.DependencyInjection;
using WalletAPI.DataAccess.Repositories.Account;

namespace WalletAPI.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddSingleton<WalletContext>()
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<IAccountRepository, AccountRepository>();

        return services;
    }
}