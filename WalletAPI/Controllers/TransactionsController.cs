using Microsoft.AspNetCore.Mvc;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Decorator;
using WalletAPI.BusinessLogic.DomainModel;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.Infrastructure.Enums;
using WalletAPI.Models.Transactions;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ILogger<TransactionsController> _logger;
    private readonly ITransactionService _transactionService;
    private readonly ITransactionsSync _transactionsSync;

    public TransactionsController(ILogger<TransactionsController> logger, 
        ITransactionService transactionService,
        ITransactionsSync transactionsSync)
    {
        _logger = logger;
        _transactionService = transactionService;
        _transactionsSync = transactionsSync;
    }
    
    [HttpGet("GetTransactionByBank", Name = "GetTransactionByBank")]
    public ActionResult<IEnumerable<Transaction>> GetTransactionByBank()
    {
        try
        {
            _transactionsSync.GetTransactionsByBank(BankType.Mono,
                DateTime.Today, DateTime.Today.AddDays(10));
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch transactions by bank");
            return BadRequest();
        }
    }
    
    
    
    [HttpGet("get", Name = "GetTransaction")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransaction()
    {
        try
        {
            var result = await _transactionService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch transactions");
            return BadRequest();
        }
    }
    
    [HttpGet("getById/{id}", Name = "GetTransactionById")]
    public async Task<ActionResult<Transaction>> GetTransactionById([FromRoute] string id)
    {
        try
        {
            var result = await _transactionService.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch transactions");
            return BadRequest();
        }
    }
    
    [HttpGet("getTodayTransactions", Name = "GetTodayTransactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTodayTransactions()
    {
        try
        {
            var result = await _transactionService.GetTodayTransactions();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch transactions");
            return BadRequest();
        }
    }

    [HttpPost("addTransaction", Name = "AddTransaction")]
    public async Task<ActionResult> Add([FromBody] CreateTransactionRequest request)
    {
        var entity = new Transaction(Guid.NewGuid().ToString(), request.Amount,
            request.AccountId, request.Type, DateTime.UtcNow);
        try
        {
            
            await _transactionService.Create(entity);
            _logger.LogInformation($"Transaction {entity.Id} successfully created");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create transaction with id={entity.Id}");
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Remove(string id)
    {
        try 
        {
            await _transactionService.Remove(id);
            _logger.LogInformation($"Transaction {id} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete transaction with id={id}");
            return BadRequest();
        }
    }

    [HttpPost("decoratorTest", Name = "decoratorTestProcessPayment")]
    public async Task ProcessPayment()
    {
        // Створюємо базовий гаманець
        IWallet basicWallet = new Wallet();

        // Додаємо логування до гаманця
        IWallet loggingWallet = new LoggingWalletDecorator(basicWallet, _logger);

        // Додаємо перевірку ліміту та логування
        IWallet walletWithLimitAndLogging = new LimitCheckWalletDecorator(loggingWallet, 500, _logger);

        // Тестуємо гаманець з обмеженням і логуванням
        walletWithLimitAndLogging.MakePayment(300); // Допустима сума
        walletWithLimitAndLogging.MakePayment(600); // Перевищує ліміт
    }
}