using AutoMapper.Internal;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.BusinessLogic.Dtos;

public sealed class AccountDto : IEquatable<AccountDto>
{
    public static readonly AccountDto Default
        = new AccountDto(string.Empty, Decimal.Zero, AccountType.None, CurrencyType.USD, DateTime.MinValue);

    public string Id { get; }
    public decimal Amount { get; }
    public AccountType Type { get; }
    public CurrencyType Currency { get; }
    public DateTime LastModified { get; }
    
    public AccountDto(string id, decimal amount, AccountType type, CurrencyType currency, DateTime lastModified)
    {
        Id = id;
        Amount = amount;
        Type = type;
        Currency = currency;
        LastModified = lastModified;
    }

    public bool Equals(AccountDto? other)
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