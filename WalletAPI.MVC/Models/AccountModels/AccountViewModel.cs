using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.AccountModels;

public class AccountViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }

    public decimal Amount { get; set; }

    public AccountType Type { get; set; }

    public CurrencyType Currency { get; set; }

    public BankType BankType { get; set; }

    public DateTime LastModified { get; set; }
}