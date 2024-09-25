using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Dtos;

public sealed class Transaction: IEquatable<Transaction>
{
    public static readonly Transaction Default
        = new Transaction(string.Empty, Decimal.Zero, String.Empty, Decimal.Zero, DateTime.MinValue);
    
    public string Id { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; init;}
    public string AccountId { get; init;}
    public DateTime LastModified { get; }

    public Transaction(string id, decimal amount, string accountId, TransactionType type, DateTime lastModified)
    {
        Id = id;
        Amount = amount;
        AccountId = accountId;
        Type = type;
        LastModified = lastModified;
    }
    
    public bool Equals(Transaction? other)
    {
        if (other == null)
            return false;
        
        return Id == other.Id && Amount == other.Amount && AccountId == other.AccountId
               && Type == other.Type && LastModified == other.LastModified;
        
    }

    public override int GetHashCode()
    {
        return (Id.GetHashCode() + Amount.GetHashCode() + AccountId.GetHashCode() + Type.GetHashCode()
                + LastModified.GetHashCode()) * 45;
    }
}