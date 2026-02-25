using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.MVC.Models.TransactionModels;

public class TransactionViewModel
{
    public string Id { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string AccountId { get; set; } = string.Empty;

    public TransactionType Type { get; set; }

    public DateTime LastModified { get; set; }
}