using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod;

public class FeeTransaction : WalletTransaction
{
    public FeeTransaction(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    protected override void DeductAmount(decimal amount)
    {
        Logger.LogInformation($"Deducting {amount} from wallet with fee.");
    }

    protected override bool HasFees()
    {
        return true; // Транзакція з комісією
    }

    protected override void ApplyFees(decimal amount)
    {
        Logger.LogInformation($"Applying fees for the transaction of amount: {amount}");
    }
}