using System.ComponentModel.DataAnnotations;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.Models.Accounts;

public class CreateAccountRequest
{
    [Required]
    public string Name { get; init;}
    [Required]
    public decimal Amount { get; init;}
    [Required]
    public AccountType Type { get; init;}
    public CurrencyType Currency { get; init;}
}

public class AccountViewModel
{
    public string Id { get; set; }
    
    public  string Name { get; set; }

    public decimal Amount { get; set; }

    public AccountType Type { get; set; }

    public CurrencyType Currency { get; set; }

    public BankType BankType { get; set; }

    public DateTime LastModified { get; set; }
}