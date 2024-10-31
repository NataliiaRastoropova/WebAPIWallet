using Microsoft.AspNetCore.Mvc;
using WalletAPI.DataAccess.Entities;
using WalletAPI.Models.Transactions;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ILogger<TransactionsController> _logger;
    // private readonly ITransactionService _transactionService;
    //
    // public TransactionsController(ILogger<TransactionsController> logger, ITransactionService transactionService)
    // {
    //     _logger = logger;
    //     _transactionService = transactionService;
    // }
    //
    // [HttpGet("get", Name = "GetTransaction")]
    // public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransaction()
    // {
    //     try
    //     {
    //         var result = await _transactionService.Get();
    //         return Ok(result);
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.LogError(e,$"Failed to fetch transactions");
    //         return BadRequest();
    //     }
    // }
    //
    // [HttpGet("getById/{id}", Name = "GetTransactionById")]
    // public async Task<ActionResult<TransactionDto>> GetTransactionById([FromRoute] string id)
    // {
    //     try
    //     {
    //         var result = await _transactionService.Get(id);
    //         return Ok(result);
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.LogError(e,$"Failed to fetch transactions");
    //         return BadRequest();
    //     }
    // }
    //
    // [HttpGet("getTodayTransactions", Name = "GetTodayTransactions")]
    // public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTodayTransactions()
    // {
    //     try
    //     {
    //         var result = await _transactionService.GetTodayTransactions();
    //         return Ok(result);
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.LogError(e,$"Failed to fetch transactions");
    //         return BadRequest();
    //     }
    // }
    //
    // [HttpPost("addTransaction", Name = "AddTransaction")]
    // public async Task<ActionResult> Add([FromBody] CreateTransactionRequest request)
    // {
    //     var entity = new TransactionDto(Guid.NewGuid().ToString(), request.Amount,
    //         request.AccountId, request.Type, DateTime.UtcNow);
    //     try
    //     {
    //         
    //         await _transactionService.Create(entity);
    //         _logger.LogInformation($"Transaction {entity.Id} successfully created");
    //         return Ok();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, $"Failed to create transaction with id={entity.Id}");
    //         return BadRequest();
    //     }
    // }

    //[HttpDelete]
    // public async Task<ActionResult> Remove(string id)
    // {
    //     try 
    //     {
    //         await _transactionService.Remove(id);
    //         _logger.LogInformation($"Transaction {id} successfully deleted");
    //         return Ok();
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, $"Failed to delete transaction with id={id}");
    //         return BadRequest();
    //     }
    // }
}