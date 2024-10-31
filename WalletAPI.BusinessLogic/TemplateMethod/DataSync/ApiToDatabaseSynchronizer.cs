using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod.DataSync;

//For API to Database synchronization
public class ApiToDatabaseSynchronizer : DataSynchronizer
{
    private ILogger _logger;

    public ApiToDatabaseSynchronizer(ILogger logger)
    {
        _logger = logger;
    }
    
    protected override void OpenSource()
    {
        _logger.LogInformation("Connecting to API...");
    }
    protected override void OpenDestination()
    {
        _logger.LogInformation("Opening database connection for writing...");
    }
    protected override void TransferData()
    {
        _logger.LogInformation("Fetching data from API and inserting into database...");
    }
    protected override void CloseSource()
    {
        _logger.LogInformation("Closing API connection...");
    }
    protected override void CloseDestination()
    {
        _logger.LogInformation("Closing database connection...");
    }
}