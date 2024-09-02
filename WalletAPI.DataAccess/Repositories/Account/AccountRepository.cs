using System.Collections.ObjectModel;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess.Repositories.Account;

public class AccountRepository : IAccountRepository
{
    private readonly WalletContext _context;

    public AccountRepository(WalletContext context)
    {
        _context = context;
    }
    
    public Task<ReadOnlyCollection<AccountEntity>> Get() =>
        Task.FromResult(_context.Accounts.ToList().AsReadOnly());

    public Task<AccountEntity?> Get(string id) =>
        Task.FromResult(_context.Accounts.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<AccountEntity>> Get(Func<AccountEntity, bool> predicate)
    {
        return Task.FromResult(_context.Accounts.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(AccountEntity entity)
    {
        _context.Accounts.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(AccountEntity entity)
    {
        foreach (var e in _context.Accounts)
        {
            if (e.Id == entity.Id)
            {
                e.Amount = entity.Amount;
                e.Currency = entity.Currency;
                e.Type = entity.Type;
                e.LastModified = DateTime.UtcNow;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Accounts.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Accounts.Remove(entity);
        }
        return Task.CompletedTask;
    }
}