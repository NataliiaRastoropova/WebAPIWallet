using WalletAPI.DataAccess.Entities;

namespace WalletAPI;

public class WalletContext
{
    public ICollection<AccountEntity> Accounts { get; }
    public ICollection<TransactionEntity> Transactions { get; }

    public WalletContext()
    {
        Accounts = new List<AccountEntity>()
        {
            new AccountEntity
            {
                Id = "1",
                Amount = 10,
                Type = "cash",
                Currency = "usd",
                LastModified = DateTime.Now
            }
        };

        Transactions = new List<TransactionEntity>
        {
            new TransactionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Amount = 1000,
                TransactionType = "income",
                LastModified = DateTime.Now,
                AccountId = "1"
            },
            new TransactionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Amount = 100,
                TransactionType = "outcome",
                LastModified = DateTime.Now,
                AccountId = "1"
            }
        };
    }
}