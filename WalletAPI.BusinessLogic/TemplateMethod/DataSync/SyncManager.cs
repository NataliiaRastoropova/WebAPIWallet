using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod.DataSync;

public class SyncManager
{
    private ILogger _logger;

    public SyncManager(ILogger logger)
    {
        _logger = logger;
    }
    
    public void SyncToFile()
    {
        DataSynchronizer dbToFileSync = new DatabaseToFileSynchronizer(_logger);
        dbToFileSync.Synchronize();
    }
    
    public void SyncToDb()
    {
        DataSynchronizer apiToDbSync = new ApiToDatabaseSynchronizer(_logger);
        apiToDbSync.Synchronize();
    }
}