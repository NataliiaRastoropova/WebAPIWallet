using System.Collections.ObjectModel;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess.Repositories.Account;

public interface IAccountRepository : IRepository<AccountEntity>
{
    public Task<ReadOnlyCollection<AccountEntity>> Get();
    public Task<AccountEntity?> Get(string id);
    public Task<ReadOnlyCollection<AccountEntity>> Get(Func<AccountEntity, bool> predicate);
    public Task Create(AccountEntity entity);
    public Task Update(AccountEntity entity);
    public Task Delete(string id);
}