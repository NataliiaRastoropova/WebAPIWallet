namespace WalletAPI.DataAccess.Entities;

public class AccountEntity : BaseEntity
{
    public decimal Amount { get; set; }
    public AccountType Type { get; set; }
    public CurrencyType Currency { get; set; }
    public DateTime LastModified { get; set; }
}