using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.FactoryMethod.Banks;

public class PrivateBankIntegration : IBankIntegration
{
    private readonly ILogger _logger;

    public PrivateBankIntegration(ILogger logger)
    {
        _logger = logger;
    }
    
    public string GetBankName()
    {
        return "PrivateBank";
    }

    public void GetTransactions(DateTime startDate, DateTime endDate)
    {
        _logger.LogInformation($"Processing to fatch transaction for dates"); 
    }
}