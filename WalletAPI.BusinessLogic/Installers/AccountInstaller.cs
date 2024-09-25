using Microsoft.Extensions.DependencyInjection;
using WalletAPI.BusinessLogic.Builder;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Services;

namespace WalletAPI.BusinessLogic.Installers;

public static class AccountInstaller
{
    public static IServiceCollection AddAccounts(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>()
            .AddScoped<IAccountBuilder, AccountBuilder>();
        
        return services;
    }
    
}