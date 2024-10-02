namespace CurrencyExchangeService.FakeBankSdk.MonoBankSdk;

public sealed class MonobankSdk : IMonobankSdk
{
    public IEnumerable<CurrencyModelMono> GetExchangeRates()
    {
        return new List<CurrencyModelMono>()
        {
            new CurrencyModelMono
            {
                Identifier = "1",
                CurrencyMONO = "USD",
                RateValue = 41
            }
        };
    }
}