using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.ErrorHandling;

public class CriticalLogHandler : LogHandler
{
    public CriticalLogHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    public override void Handle(LogLevel level, string message)
    {
        if (level == LogLevel.Critical)
        {
            Logger.LogCritical($"{message}");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(level, message);
        }
    }
}