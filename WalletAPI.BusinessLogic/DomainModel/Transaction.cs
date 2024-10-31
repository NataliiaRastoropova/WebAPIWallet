using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.DomainModel;

public sealed class Transaction: IEquatable<Transaction>, ICloneable
{
    public static readonly Transaction Default
        = new Transaction(string.Empty, Decimal.Zero, String.Empty, Decimal.Zero, DateTime.MinValue);
    
    public string Id { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; }
    public string AccountId { get; }
    public DateTime LastModified { get; }
    public TransactionCategory Category { get; }

    public Transaction(string id, decimal amount, string accountId, 
        TransactionType type, DateTime lastModified)
    {
        Id = id;
        Amount = amount;
        AccountId = accountId;
        Type = type;
        LastModified = lastModified;
    }
    
    public Transaction(string id, decimal amount, string accountId, 
        TransactionType type, DateTime lastModified, TransactionCategory category)
    {
        Id = id;
        Amount = amount;
        AccountId = accountId;
        Type = type;
        LastModified = lastModified;
        Category = category;
    }
    
    public bool Equals(Transaction? other)
    {
        if (other == null)
            return false;
        
        return Id == other.Id && Amount == other.Amount && AccountId == other.AccountId
               && Type == other.Type && LastModified == other.LastModified;
        
    }

    public override int GetHashCode()
    {
        return (Id.GetHashCode() + Amount.GetHashCode() + AccountId.GetHashCode() + Type.GetHashCode()
                + LastModified.GetHashCode()) * 45;
    }
    
    // MemberwiseClone Method in C#:
    //The MemberwiseClone method is part of the System.Object class and creates a shallow copy of the given object. 
    
    //MemberwiseClone Method only copies the non-static fields of the object to the new object.
    
    //In copying, if a field is a value type, a bit-by-bit copy of the field is performed.
    //If a field is a reference type, the reference is copied, but the referenced object is not.
    public object Clone()
    {
        // Повертаємо поверхневу копію об'єкта
        //return this.MemberwiseClone();
        
        // Створюємо новий об'єкт гаманця з глибокою копією властивостей
        return new Transaction(Id, Amount, AccountId, Type, LastModified, Category.DeepCopy());
    }
}