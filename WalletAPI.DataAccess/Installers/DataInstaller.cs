using Microsoft.Extensions.DependencyInjection;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.DataAccess.Repositories.Factory;

namespace WalletAPI.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddSingleton<WalletContext>()
            // .AddSingleton<IRepositoryFactory, RepositoryFactory>()
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<IAccountRepository, AccountRepository>();

        return services;
    }
}