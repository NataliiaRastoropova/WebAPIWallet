using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod;

public class StandardTransaction : WalletTransaction
{
    public StandardTransaction(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    protected override void DeductAmount(decimal amount)
    {
        Logger.LogInformation($"Deducting {amount} from standard wallet.");
    }
}