using Microsoft.AspNetCore.Mvc;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ILogger<TransactionsController> _lg;
    private readonly WalletContext _context = new WalletContext();

    public TransactionsController(ILogger<TransactionsController> log)
    {
        _lg = log;
    }
    
    [HttpGet("get", Name = "GetTransaction")]
    public IEnumerable<TransactionEntity> GetTransaction()
    {
        try
        {
            return _context.Transactions.ToList();
        }
        catch (Exception e)
        {
            _lg.LogError(e,$"Failed to fetch transactions");
            return null;
        }
    }
    
    [HttpGet("getById/{id}", Name = "GetTransactionById")]
    public TransactionEntity GetTransactionById([FromRoute] string id)
    {
        try
        {
            return _context.Transactions.First(e => e.Id == id);
        }
        catch (Exception e)
        {
            _lg.LogError(e,$"Failed to fetch transactions");
            return new TransactionEntity();
        }
    }
    
    [HttpGet("getTodayTransactions", Name = "GetTodayTransactions")]
    public IEnumerable<TransactionEntity> GetTodayTransactions()
    {
        try
        {
            return _context.Transactions.Where( t => t.LastModified.Date == DateTime.UtcNow.Date);
        }
        catch (Exception e)
        {
            _lg.LogError(e,$"Failed to fetch transactions");
            return null;
        }
    }

    [HttpPost("addTransaction", Name = "AddTransaction")]
    public void Add([FromBody] TransactionEntity request)
    {
        var entity = new TransactionEntity
        {
            Id = request.Id,
            Amount = request.Amount,
            LastModified = request.LastModified,
            AccountId = request.AccountId,
            TransactionType = request.TransactionType
        };
        try
        {
            _context.Transactions.Add(entity);
        }
        catch (Exception ex)
        {
            _lg.LogError(ex, $"Failed to create transaction with id={entity.Id}");
        }
    }

    [HttpDelete]
    public void Remove(string id)
    {
        try 
        {
            var entity = _context.Transactions.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _context.Transactions.Remove(entity);
            }
            _lg.LogInformation($"Transaction {id} successfully deleted");
        }
        catch (Exception ex)
        {
            _lg.LogError(ex, $"Failed to delete transaction with id={id}");
        }
    }
}