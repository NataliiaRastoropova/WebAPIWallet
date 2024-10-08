using System.ComponentModel.DataAnnotations;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.Models.Transactions;

public class CreateTransactionRequest
{
    [Required]
    public string AccountId { get; init; }
    [Required]
    public decimal Amount { get; init; }
    [Required]
    public TransactionType Type { get; init;}
}