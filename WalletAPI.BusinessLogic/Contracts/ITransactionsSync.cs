using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Contracts;

public interface ITransactionsSync
{
    public void GetTransactionsByBank(BankType bankType, DateTime startDate, DateTime endDate);
}