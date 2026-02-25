using System.ComponentModel.DataAnnotations;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.AccountModels;

public class EditAccountViewModel
{
    public string Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public AccountType Type { get; set; }

    [Required]
    public CurrencyType Currency { get; set; }

    public BankType BankType { get; set; }
}