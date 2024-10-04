using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.FactoryMethod.Factories;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Services;

public class TransactionsSync : ITransactionsSync
{
    private readonly ILoggerFactory _loggerFactory;

    public TransactionsSync(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
    }
    
    public void GetTransactionsByBank(BankType bankType, DateTime startDate, DateTime endDate)
    {
        BankIntegrationFactory bank;
        
        switch (bankType)
        {
            case BankType.Mono:
                bank = new MonobankIntegrationFactory(_loggerFactory);
                break;
            case BankType.PrivateBank:
                bank = new PrivateBankIntegrationFactory(_loggerFactory);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(bankType), bankType, null);
        }
        
        bank.BankSync(startDate, endDate);
    }
}