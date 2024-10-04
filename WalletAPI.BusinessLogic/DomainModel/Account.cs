using AutoMapper.Internal;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Dtos;

public sealed class Account : IEquatable<Account>
{
    public static readonly Account Default
        = new Account(string.Empty, Decimal.Zero, AccountType.None, 
            CurrencyType.USD, DateTime.MinValue, Infrastructure.Enums.BankType.None);

    public string Id { get; }
    public decimal Amount { get; }
    public AccountType Type { get; }
    public CurrencyType Currency { get; }
    public DateTime LastModified { get; }
    
    public BankType BankType { get; }
    
    public Account(string id, decimal amount, AccountType type, 
        CurrencyType currency, DateTime lastModified, BankType bankType)
    {
        Id = id;
        Amount = amount;
        Type = type;
        Currency = currency;
        LastModified = lastModified;
        BankType = bankType;
    }

    public bool Equals(Account? other)
    {
        if (other == null)
            return false;
        
        return Id == other.Id && Amount == other.Amount && Type == other.Type
                && Currency == other.Currency && LastModified == other.LastModified;
        
    }

    public override int GetHashCode()
    {
        return (Id.GetHashCode() + Amount.GetHashCode() + Type.GetHashCode() + Currency.GetHashCode()
            + LastModified.GetHashCode()) * 45;
    }
}