using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.Infrastructure.Exceptions;

namespace WalletAPI.DataAccess.Repositories.Factory;

public sealed class RepositoryFactory : IRepositoryFactory
{
    // private instance - single instance
    private static IRepositoryFactory _instance;

    // locker object for thread safe instance creation
    private static readonly object Locker = new object();
    
    // private constructor to restrict object creation from outside
    private RepositoryFactory() {}

    // static method for getting single instance of the factory
    public static IRepositoryFactory Instance() 
    {
        if(_instance != null) 
        {
            return _instance;
        }

        lock(Locker)
        {
            if(_instance == null) 
            {
                _instance = new RepositoryFactory();
            }
        }

        return _instance;
    }
    
    public IRepository Instantiate<TEntity>(WalletContext context) where TEntity : BaseEntity
    {
        return typeof(TEntity).Name switch
        {
            nameof(AccountEntity) => new AccountRepository(context),
            nameof(TransactionEntity) => new TransactionRepository(context),
            _ => throw new UnsupportedRepositoryTypeException(typeof(TEntity).Name)
        };
    }
}