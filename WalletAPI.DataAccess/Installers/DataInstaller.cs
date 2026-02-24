using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.DataAccess.Repositories.Factory;

namespace WalletAPI.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, string? connectionString)
    {
        services
            .AddDbContext<WalletContext>(options => options.UseNpgsql(connectionString))
            // .AddSingleton<IRepositoryFactory, RepositoryFactory>()
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<IAccountRepository, AccountRepository>();

        return services;
    }
}