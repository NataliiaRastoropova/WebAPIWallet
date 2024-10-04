using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.FactoryMethod.Banks;

namespace WalletAPI.BusinessLogic.FactoryMethod.Factories;

public class PrivateBankIntegrationFactory : BankIntegrationFactory
{
    private readonly ILoggerFactory _loggerFactory;

    public PrivateBankIntegrationFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
    }
    
    public override IBankIntegration CreateBankIntegration()
    {
        return new PrivateBankIntegration(_loggerFactory.CreateLogger<MonobankIntegration>());
    }
}