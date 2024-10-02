using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.FactoryMethod.Banks;

namespace WalletAPI.BusinessLogic.FactoryMethod.Factories;

public class MonobankIntegrationFactory : BankIntegrationFactory
{
    private readonly ILoggerFactory _loggerFactory;

    public MonobankIntegrationFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
    }
    
    public override IBankIntegration CreateBankIntegration()
    {
        return new MonobankIntegration(_loggerFactory.CreateLogger<MonobankIntegration>());
    }
}