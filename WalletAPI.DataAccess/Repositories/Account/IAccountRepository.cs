using System.Collections.ObjectModel;

namespace WalletAPI.DataAccess.Repositories.Account;

public interface IAccountRepository
{
    public Task<ReadOnlyCollection<AccountEntity>> Get();
    public Task<AccountEntity?> Get(string id);
    public Task<ReadOnlyCollection<AccountEntity>> Get(Func<AccountEntity, bool> predicate);
    public Task Create(AccountEntity entity);
    public Task Update(AccountEntity entity);
    public Task Delete(string id);
}