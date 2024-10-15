using CurrencyExchangeService.FakeBankSdk;
using CurrencyExchangeService.FakeBankSdk.MonoBankSdk;

namespace WalletAPI.BusinessLogic.Adapters;
 // Adapter
public sealed class MonobankCurrencyRatesAdapter : ICurrencyExchangeAdapter
{
    private readonly IMonobankSdk _sdk;
    public MonobankCurrencyRatesAdapter(IMonobankSdk sdk)
    {
        _sdk = sdk;
    }
    
    public IEnumerable<CurrencyRateModel> Get()
    {
        // create auth request for sdk access
        
        var rawData = _sdk.GetExchangeRates();

        // some validation rules
        // data processing
        
        // adapting sdk model to the target project model
        return rawData.Select(m => new CurrencyRateModel());
    }
}