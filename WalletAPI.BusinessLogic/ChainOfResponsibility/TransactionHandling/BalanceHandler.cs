using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;

public class BalanceHandler : Handler<Transaction>
{
    private decimal _balance;

    public BalanceHandler(decimal balance, ILoggerFactory loggerFactory) : base(loggerFactory)
    {
        _balance = balance;
    }

    public override void Handle(Transaction transaction)
    {
        if (_balance >= transaction.Amount)
        {
            Logger.LogInformation("Balance check passed.");
            base.Handle(transaction);
        }
        else
        {
            Logger.LogCritical("Insufficient balance.");
        }
    }
}