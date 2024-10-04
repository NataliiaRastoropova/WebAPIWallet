namespace WalletAPI.BusinessLogic.DomainModel;

public class TransactionCategory
{
    public string Id { get; set; }
    public string Name { get; set; }

    public TransactionCategory(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public TransactionCategory DeepCopy()
    {
        // Створення глибокої копії об'єкта TransactionCategory
        return new TransactionCategory(Id, Name);
    }
}