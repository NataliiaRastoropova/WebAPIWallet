using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.DataAccess.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.ToTable("Transaction");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("text");

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.TransactionType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.LastModified)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(x => x.AccountId)
            .HasColumnType("text")
            .IsRequired();

        builder.HasIndex(x => x.AccountId);
    }
}