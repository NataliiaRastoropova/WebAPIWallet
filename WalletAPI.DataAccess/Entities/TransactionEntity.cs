namespace WalletAPI.DataAccess.Entities;

public class TransactionEntity : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime LastModified { get; set; }
    public string AccountId { get; set; }
    public TransactionType TransactionType { get; set; }
}