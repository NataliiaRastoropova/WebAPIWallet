using WalletAPI.BusinessLogic.ChainOfResponsibility.ErrorHandling;
using WalletAPI.Infrastructure.Exceptions;

namespace WalletAPI.Middlewares;

public class WebRequestsLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly LogHandler _logHandler;

    public WebRequestsLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logHandler = new WarningHandler(loggerFactory);
        _logHandler.SetNext(new CriticalLogHandler(loggerFactory));
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (WrongUserInputException wrongUserInputException)
        {
            _logHandler.Handle(LogLevel.Warning, $"User provided invalid input: {wrongUserInputException.Message}");
        }
        catch (Exception ex)
        {
            _logHandler.Handle(LogLevel.Critical, $"Unexpected error occured: {ex.Message}");
        }
    }
}