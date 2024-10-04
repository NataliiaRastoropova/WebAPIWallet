using System.ComponentModel.DataAnnotations;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.Models.Accounts;

public class UpdateAccountRequest
{
    [Required]
    public string Id { get; init; }
    [Required]
    public decimal Amount { get; init;}
    [Required]
    public AccountType Type { get; init;}
    public CurrencyType Currency { get; init;}
    
    public BankType BankType { get; init;}
}