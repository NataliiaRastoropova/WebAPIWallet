namespace WalletAPI.BusinessLogic.Adapters;

public sealed class CurrencyRateModel
{
    public string Id { get; init; }
    public string Currency { get; init; }
    public float Rate { get; init; }
    public DateTime UpdatedAt { get; init; }
}