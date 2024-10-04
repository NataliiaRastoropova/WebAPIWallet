using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Contracts;

public interface ITransactionService
{
    Task<IReadOnlyList<Transaction>> Get();
    Task<Transaction> Get(string id);
    Task<IReadOnlyList<Transaction>> GetTodayTransactions();
    Task Create(Transaction transaction);
    Task Remove(string id);
}