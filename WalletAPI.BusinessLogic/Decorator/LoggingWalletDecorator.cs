using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.Decorator;

public class LoggingWalletDecorator : WalletDecorator
{
    private readonly ILogger _logger;
    
    public LoggingWalletDecorator(IWallet wallet, ILogger logger) : base(wallet)
    {
        _logger = logger;
    }

    public override void MakePayment(decimal amount)
    {
        _logger.LogInformation($"[LOG] Payment of {amount} is being processed.");
        base.MakePayment(amount);
        _logger.LogInformation($"[LOG] Payment of {amount} has been processed.");
    }
}