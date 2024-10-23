using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;

public class LimitHandler : Handler<Transaction>
{
    private decimal _limit;

    public LimitHandler(decimal limit, ILoggerFactory loggerFactory) : base(loggerFactory)
    {
        _limit = limit;
    }

    public override void Handle(Transaction transaction)
    {
        if (transaction.Amount <= _limit)
        {
            Logger.LogInformation("Limit check passed.");
            base.Handle(transaction);
        }
        else
        {
            Logger.LogCritical("Transaction exceeds the limit.");
        }
    }
}