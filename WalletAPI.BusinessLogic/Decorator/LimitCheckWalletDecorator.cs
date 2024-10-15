using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.Decorator;

public class LimitCheckWalletDecorator : WalletDecorator
{
    private readonly ILogger _logger;
    private decimal _limit;

    public LimitCheckWalletDecorator(IWallet wallet, decimal limit, ILogger logger) : base(wallet)
    {
        _limit = limit;
        _logger = logger;
    }

    public override void MakePayment(decimal amount)
    {
        if (amount > _limit)
        {
            _logger.LogError($"[ERROR] Payment of {amount} exceeds the limit of {_limit}.");
        }
        else
        {
            base.MakePayment(amount);
        }
    }
}