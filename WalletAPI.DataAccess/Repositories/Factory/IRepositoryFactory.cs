using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess.Repositories.Factory;

public interface IRepositoryFactory
{
     IRepository Instantiate<TEntity>(WalletContext context) where TEntity : BaseEntity;
}