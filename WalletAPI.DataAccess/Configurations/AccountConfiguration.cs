using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess.Configurations;

public class AccountConfiguration  : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.ToTable("Account");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("text");

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.BankType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.LastModified)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.HasMany(x => x.Transactions)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}