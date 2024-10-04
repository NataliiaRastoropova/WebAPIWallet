namespace CurrencyExchangeService.FakeBankSdk.MonoBankSdk;

public interface IMonobankSdk
{
    IEnumerable<CurrencyModelMono> GetExchangeRates();
}