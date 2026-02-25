using System.ComponentModel.DataAnnotations;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.TransactionModels;

public class CreateTransactionViewModel
{
    public string Id { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public string AccountId { get; set; } = string.Empty;

    [Required]
    public TransactionType Type { get; set; }
}