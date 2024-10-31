using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;

public class TransactionHandlerBuilder
{
    private readonly ILoggerFactory _loggerFactory;

    private IHandler<Transaction> _limitHandler;
    private IHandler<Transaction> _balanceHandler;
    private IHandler<Transaction> _handler;

    public TransactionHandlerBuilder(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
        
    public TransactionHandlerBuilder Create()
    {
        _handler = new TransactionHandler(_loggerFactory);
        return this;
    }

    public TransactionHandlerBuilder SetLimit(int limit)
    {
        _limitHandler = new LimitHandler(limit, _loggerFactory);
        return this;
    }

    public TransactionHandlerBuilder SetBalance(int balance)
    {
        _balanceHandler = new BalanceHandler(balance, _loggerFactory);
        return this;
    }

    public IHandler<Transaction> Build()
    {
        if (_handler == null)
        {
            throw new ArgumentNullException("Call Create method first");
        }

        if (_limitHandler != null)
        {
            _handler.SetNext(_limitHandler);
        }
            
        if (_balanceHandler != null)
        {
            _handler.SetNext(_balanceHandler);
        }

        return _handler;
    }
}