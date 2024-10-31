using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess;

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
                Type = AccountType.Cash,
                Currency = CurrencyType.USD,
                LastModified = DateTime.UtcNow
            },
            new AccountEntity
            {
                Id = "2",
                Amount = 20,
                Type = AccountType.Debit,
                Currency = CurrencyType.JPY,
                LastModified = DateTime.UtcNow
            },
            new AccountEntity
            {
                Id = "3",
                Amount = 30,
                Type = AccountType.Credit,
                Currency = CurrencyType.CAD,
                LastModified = DateTime.UtcNow
            }
        };

        Transactions = new List<TransactionEntity>
        {
            new TransactionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Amount = 1000,
                TransactionType = TransactionType.Income,
                LastModified = DateTime.UtcNow,
                AccountId = "1"
            },
            new TransactionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Amount = 100,
                TransactionType = TransactionType.Outcome,
                LastModified = DateTime.UtcNow,
                AccountId = "2"
            },
            new TransactionEntity
            {
                Id = Guid.NewGuid().ToString(),
                Amount = 500,
                TransactionType = TransactionType.Income,
                LastModified = DateTime.UtcNow,
                AccountId = "3"
            }
        };
    }
}