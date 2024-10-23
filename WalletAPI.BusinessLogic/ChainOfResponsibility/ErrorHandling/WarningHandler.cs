using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.ErrorHandling;

public class WarningHandler : LogHandler
{
    public WarningHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    public override void Handle(LogLevel level, string message)
    {
        if (level == LogLevel.Warning)
        {
            Logger.LogCritical($"{message}");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(level, message);
        }
    }
}