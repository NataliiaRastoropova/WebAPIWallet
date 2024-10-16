using WalletAPI.BusinessLogic.Command.TransactionCommands;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;

    public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }

    public async Task<IReadOnlyList<Transaction>> Get()
    {
        var command = new GetTransactionsCommand(_transactionRepository);
        var transactions = await command.Execute();

        
      //  var transactions = await _transactionRepository.Get();
        if (transactions == null)
            return new List<Transaction>();
        
        return  transactions.Select(e => new Transaction(
                e.Id, e.Amount, e.AccountId, e.TransactionType, e.LastModified)).ToList().AsReadOnly();
    }
    
    public async Task<Transaction> Get(string id)
    {
        var transaction = await _transactionRepository.Get(id);

        if (transaction == null)
            return Transaction.Default;

        return new Transaction(transaction.Id, transaction.Amount, 
            transaction.AccountId, transaction.TransactionType, transaction.LastModified);
    }
    
    public async Task<IReadOnlyList<Transaction>> GetTodayTransactions()
    {
        var transactions = await _transactionRepository.Get(t 
            => t.LastModified.Date == DateTime.UtcNow.Date);
        if (transactions == null)
            return new List<Transaction>();
        
        return  transactions.Select(e => new Transaction(
            e.Id, e.Amount, e.AccountId, e.TransactionType, e.LastModified)).ToList().AsReadOnly();
    }

    public async Task Create(Transaction transaction)
    {
        if (transaction != Transaction.Default)
        {
            var account = await _accountRepository.Get(transaction.AccountId);

            if (account == null)
                throw new ArgumentNullException($"Account not found by id={transaction.AccountId}");
            
            await _transactionRepository.Create(new TransactionEntity
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    AccountId = transaction.AccountId,
                    TransactionType = transaction.Type,
                    LastModified = transaction.LastModified
                });

            switch (transaction.Type)
            {
                case TransactionType.Income:
                    account.Amount += transaction.Amount;
                    break;
                case TransactionType.Outcome:
                    account.Amount -= transaction.Amount;
                    break;
            }

            await _accountRepository.Update(account);
        }
    }

    public async Task Remove(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            throw new ArgumentNullException();
        
        await _transactionRepository.Delete(id);
    }
}