using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod.DataSync;

//Concrete Implementations:
//For Database to File synchronization
public class DatabaseToFileSynchronizer : DataSynchronizer
{
    private ILogger _logger;

    public DatabaseToFileSynchronizer(ILogger logger)
    {
        _logger = logger;
    }
    
    protected override void OpenSource()
    {
        _logger.LogInformation("Opening database connection...");
    }
    protected override void OpenDestination()
    {
        _logger.LogInformation("Opening file for writing...");
    }
    protected override void TransferData()
    {
        _logger.LogInformation("Reading data from database and writing to file...");
    }
    protected override void CloseSource()
    {
        _logger.LogInformation("Closing database connection...");
    }
    protected override void CloseDestination()
    {
        _logger.LogInformation("Closing file...");
    }
}