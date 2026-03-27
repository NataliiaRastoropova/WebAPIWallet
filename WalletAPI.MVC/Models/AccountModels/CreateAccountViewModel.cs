using System.ComponentModel.DataAnnotations;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.AccountModels;

public class CreateAccountViewModel
{
    [Required(ErrorMessage = "Account name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Account name must be between 2 and 100 characters.")]
    [Display(Name = "Account Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Balance is required.")]
    [Range(typeof(decimal), "0", "1000000000", ErrorMessage = "Balance must be between 0 and 1,000,000,000.")]
    [Display(Name = "Balance")]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Account type is required.")]
    [Display(Name = "Account Type")]
    public AccountType Type { get; set; }

    [Required(ErrorMessage = "Currency is required.")]
    [Display(Name = "Currency")]
    public CurrencyType Currency { get; set; }

    [Required(ErrorMessage = "Bank type is required.")]
    [Display(Name = "Bank")]
    public BankType BankType { get; set; }
}