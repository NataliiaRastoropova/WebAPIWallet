using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;

namespace WalletAPI.BusinessLogic.Command.TransactionCommands;

public class GetTransactionCommand :IAsyncCommand<string, TransactionEntity>
{  
    private readonly ITransactionRepository _repository;
    
    public GetTransactionCommand(ITransactionRepository repository)
    {
        _repository = repository;
    }
    
    public Task<TransactionEntity> Execute(string data)
    {
        return _repository.Get(data)!;
    }
}