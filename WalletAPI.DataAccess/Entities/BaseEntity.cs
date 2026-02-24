namespace WalletAPI.DataAccess.Entities;

public class BaseEntity
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
}