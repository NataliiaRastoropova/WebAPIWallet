namespace WalletAPI.BusinessLogic.Adapters;

// Target
public interface ICurrencyExchangeAdapter
{
    IEnumerable<CurrencyRateModel> Get();
}