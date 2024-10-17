using System.Collections.ObjectModel;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;

namespace WalletAPI.BusinessLogic.Command.TransactionCommands;

public class GetTransactionsCommand : IAsyncCommand<ReadOnlyCollection<TransactionEntity>>
{
    private readonly ITransactionRepository _repository;
    
    public GetTransactionsCommand(ITransactionRepository repository)
    {
        _repository = repository;
    }
        
    public Task<ReadOnlyCollection<TransactionEntity>> Execute()
    {
        return _repository.Get();
    }
}