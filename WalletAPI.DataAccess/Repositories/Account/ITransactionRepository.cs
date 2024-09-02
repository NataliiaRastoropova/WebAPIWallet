using System.Collections.ObjectModel;

namespace WalletAPI.DataAccess.Repositories.Account;

public interface ITransactionRepository
{
    public Task<ReadOnlyCollection<TransactionEntity>> Get();
    public Task<TransactionEntity?> Get(string id);
    public Task<ReadOnlyCollection<TransactionEntity>> Get(Func<TransactionEntity, bool> predicate);
    public Task Create(TransactionEntity entity);
    public Task Update(TransactionEntity entity);
    public Task Delete(string id);
}