namespace WalletAPI.DataAccess.Entities;

public class AccountEntity
{
    public string Id { get; init; }
    public decimal Amount { get; set; }
    public AccountType Type { get; set; }
    public CurrencyType Currency { get; set; }
    public DateTime LastModified { get; set; }
}