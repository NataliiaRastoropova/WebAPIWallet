using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.FactoryMethod.Banks;

public class MonobankIntegration : IBankIntegration
{
    private readonly ILogger<MonobankIntegration> _logger;

    public MonobankIntegration(ILogger<MonobankIntegration> logger)
    {
        _logger = logger;
    }
    
    public string GetBankName()
    {
        return "PrivateBank";
    }

    public void GetTransactions(DateTime startDate, DateTime endDate)
    {
        _logger.LogInformation($"Processing to fetch transaction for dates"); 
    }
}