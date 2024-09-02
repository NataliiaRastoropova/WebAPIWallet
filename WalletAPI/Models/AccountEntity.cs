namespace WalletAPI.DataAccess.Entities;

public class AccountEntity
{
    public string Id { get; init; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Currency { get; set; }
    public DateTime LastModified { get; set; }
}