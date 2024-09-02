using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Contracts;

public interface ITransactionService
{
    Task<IReadOnlyList<TransactionDto>> Get();
    Task<TransactionDto> Get(string id);
    Task<IReadOnlyList<TransactionDto>> GetTodayTransactions();
    Task Create(TransactionDto transaction);
    Task Remove(string id);
}