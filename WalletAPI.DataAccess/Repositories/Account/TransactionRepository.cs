using System.Collections.ObjectModel;

namespace WalletAPI.DataAccess.Repositories.Account;

public class TransactionRepository : ITransactionRepository
{
    private readonly WalletContext _context;

    public TransactionRepository(WalletContext context)
    {
        _context = context;
    }
    
    public Task<ReadOnlyCollection<TransactionEntity>> Get() =>
        Task.FromResult(_context.Transactions.ToList().AsReadOnly());

    public Task<TransactionEntity?> Get(string id) =>
        Task.FromResult(_context.Transactions.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<TransactionEntity>> Get(Func<TransactionEntity, bool> predicate)
    {
        return Task.FromResult(_context.Transactions.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(TransactionEntity entity)
    {
        _context.Transactions.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(TransactionEntity entity)
    {
        foreach (var e in _context.Transactions)
        {
            if (e.Id == entity.Id)
            {
                e.Amount = entity.Amount;
                e.AccountId = entity.AccountId;
                e.TransactionType = entity.TransactionType;
                e.LastModified = DateTime.UtcNow;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Transactions.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Transactions.Remove(entity);
        }
        return Task.CompletedTask;
    }
}