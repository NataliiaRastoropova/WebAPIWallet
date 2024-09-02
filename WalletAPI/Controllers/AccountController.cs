using Microsoft.AspNetCore.Mvc;
using WalletAPI.DataAccess.Entities;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<TransactionsController> _logger;
    private readonly WalletContext CONTEXT = new WalletContext();

    public AccountController(ILogger<TransactionsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("get", Name = "GetAccount")]
    public IEnumerable<AccountEntity> GetAccount()
    {
        try
        {
            return CONTEXT.Accounts.ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch accounts");
            return null;
        }
    }
    
    [HttpGet("getById/{id}", Name = "GetAccountById")]
    public AccountEntity GetAccountById([FromRoute] string id)
    {
        try
        {
            return CONTEXT.Accounts.First(a => a.Id == id);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch accounts");
            return null;
        }
    }
    
    [HttpPost]
    public void Add([FromBody] AccountEntity request)
    {
        var E = new AccountEntity
        {
            Id = request.Id,
            Amount = request.Amount,
            Type = request.Type,
            Currency = request.Currency,
            LastModified = request.LastModified
        };
        try
        {
            CONTEXT.Accounts.Add(E);
            _logger.LogInformation($"Account {E.Id} successfully created");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create account with id={E.Id}");
        }
    }
    
    [HttpPut]
    public void Update([FromBody] AccountEntity request)
    {
        var sm = CONTEXT.Accounts.First(e => e.Id == request.Id);
        
        try
        {
            sm.Amount = request.Amount;
            sm.Currency = request.Currency;
            sm.Type = request.Type;
            sm.LastModified = request.LastModified;
            _logger.LogInformation($"Account {sm.Id} successfully updated");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to update account with id={sm.Id}");
        }
    }
    
    [HttpDelete]
    public void Remove(string id)
    {
        try 
        {
            var ds = CONTEXT.Accounts.First(e => e.Id == id);
            if (ds != null)
            {
                CONTEXT.Accounts.Remove(ds);
            }
            _logger.LogInformation($"Account {id} successfully deleted");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete account with id={id}");
        }
    }
}