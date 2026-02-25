using Microsoft.EntityFrameworkCore;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.DataAccess;

public class WalletContext : DbContext
{
    public WalletContext(DbContextOptions<WalletContext> options)
        : base(options) { }
    
    public DbSet<AccountEntity> Accounts { get; init; }
    public DbSet<TransactionEntity> Transactions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletContext).Assembly);
        modelBuilder.Entity<AccountEntity>().HasData(
            new AccountEntity
                {
                    Id = "1",
                    Name = "admin",
                    Amount = 10,
                    Type = AccountType.Cash,
                    Currency = CurrencyType.USD,
                    BankType = BankType.PrivateBank,
                    LastModified = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
                },
                new AccountEntity
                {
                    Id = "2",
                    Name = "user1",
                    Amount = 20,
                    Type = AccountType.Debit,
                    Currency = CurrencyType.JPY,
                    BankType = BankType.Mono,
                    LastModified = new DateTime(2024, 01, 02, 0, 0, 0, DateTimeKind.Utc)
                },
                new AccountEntity
                {
                    Id = "3",
                    Name = "user2",
                    Amount = 30,
                    Type = AccountType.Credit,
                    Currency = CurrencyType.CAD,
                    BankType = BankType.PrivateBank,
                    LastModified = new DateTime(2024, 06, 02, 0, 0, 0, DateTimeKind.Utc)
                });

        modelBuilder.Entity<TransactionEntity>().HasData(
            new TransactionEntity
            {
                Id = "aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
                Amount = 1000,
                TransactionType = TransactionType.Income,
                LastModified = new DateTime(2024, 01, 02, 0, 0, 0, DateTimeKind.Utc),
                AccountId = "1"
            },
            new TransactionEntity
            {
                Id = "bbbbbbb2-bbbb-bbbb-bbbb-bbbbbbbbbbbb",
                Amount = 100,
                TransactionType = TransactionType.Outcome,
                LastModified = new DateTime(2024, 01, 03, 0, 0, 0, DateTimeKind.Utc),
                AccountId = "2"
            },
            new TransactionEntity
            {
                Id = "ccccccc3-cccc-cccc-cccc-cccccccccccc",
                Amount = 500,
                TransactionType = TransactionType.Income,
                LastModified = new DateTime(2024, 01, 05, 0, 0, 0, DateTimeKind.Utc),
                AccountId = "3"
            });
    }
}