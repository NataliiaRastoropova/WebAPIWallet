using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;

public class TransactionHandler : Handler<Transaction>
{
    public TransactionHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    public override void Handle(Transaction transaction)
    {
        Logger.LogInformation($"Processing {transaction.Type} transaction of {transaction.Amount}.");
        base.Handle(transaction);
    }
}