using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;
using WalletAPI.BusinessLogic.ChainOfResponsibility.ValidationHandling;
using WalletAPI.BusinessLogic.Command.TransactionCommands;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.DomainModel;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.BusinessLogic.Enumerator;
using WalletAPI.BusinessLogic.TemplateMethod;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private ILoggerFactory _loggerFactory;

    public TransactionService(ITransactionRepository transactionRepository, 
        IAccountRepository accountRepository,
        ILoggerFactory loggerFactory)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
        _loggerFactory = loggerFactory;
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
            ValidateTransaction(transaction);
            
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

    private void ValidateTransactionWithBuilder(Transaction transaction)
    {
        TransactionHandlerBuilder builder = new TransactionHandlerBuilder(_loggerFactory);

        IHandler<Transaction> transactionHandler = builder.Create().SetLimit(200).SetBalance(500).Build();

        transactionHandler.Handle(transaction);
    }

    private void ValidateTransaction(Transaction transaction)
    {
        // Створюємо ланцюжок обробників
        IHandler<Transaction> balanceHandler = new BalanceHandler(500 , _loggerFactory);
        IHandler<Transaction> limitHandler = new LimitHandler(200, _loggerFactory);
        IHandler<Transaction> transactionHandler = new TransactionHandler(_loggerFactory);

        // Зв'язуємо обробники
        balanceHandler.SetNext(limitHandler).SetNext(transactionHandler);

        // Запускаємо обробку запиту
        balanceHandler.Handle(transaction);
    }

    public async Task Remove(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            throw new ArgumentNullException();
        
        await _transactionRepository.Delete(id);
    }

    public async Task Iterator()
    {
        TransactionCollection transactions = new TransactionCollection();
        
        // Ітеруємо через колекцію транзакцій за допомогою foreach
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Id}: {transaction.Amount}");
        }
    }

    public void TransactionManager()
    {
        WalletTransaction standardTransaction = new StandardTransaction(_loggerFactory);
        WalletTransaction feeTransaction = new FeeTransaction(_loggerFactory);

        Console.WriteLine("Standard transaction:");
        standardTransaction.ProcessTransaction(100);

        Console.WriteLine("\nFee transaction:");
        feeTransaction.ProcessTransaction(100);
    }
}