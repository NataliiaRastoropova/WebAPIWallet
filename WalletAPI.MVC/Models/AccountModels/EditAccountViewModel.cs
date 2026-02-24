using System.ComponentModel.DataAnnotations;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.AccountModels;

public class EditAccountViewModel
{
    [Required]
    public string Id { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public AccountType Type { get; set; }

    [Required]
    public CurrencyType Currency { get; set; }

    public BankType BankType { get; set; }
}