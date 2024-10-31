using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.ErrorHandling;

public abstract class LogHandler
{
    protected LogHandler? NextHandler;
    protected readonly ILogger Logger;

    protected LogHandler(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger(nameof(LogHandler));
    }

    public void SetNext(LogHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public abstract void Handle(LogLevel level, string message);
}