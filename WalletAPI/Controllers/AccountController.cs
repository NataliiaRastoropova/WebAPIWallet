using Microsoft.AspNetCore.Mvc;
using WalletAPI.BusinessLogic.Builder;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.DomainModel;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.DataAccess.Repositories.Factory;
using WalletAPI.Infrastructure.Enums;
using WalletAPI.Models.Accounts;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<TransactionsController> _logger;
    private readonly IAccountService _accountService;
    private readonly IAccountBuilder _builder;

    public AccountController(ILogger<TransactionsController> logger, 
        IAccountService accountService,
        IAccountBuilder accountBuilder)
    {
        _logger = logger;
        _accountService = accountService;
        _builder = accountBuilder;
    }
    
    [HttpGet("get", Name = "GetAccount")]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
    {
        try
        {
            var result = await _accountService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch accounts");
            return BadRequest();
        }
    }
    
    [HttpGet("getById/{id}", Name = "GetAccountById")]
    public async Task<ActionResult<Transaction>> GetAccountById([FromRoute] string id)
    {
        try
        {
            var result = await _accountService.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"Failed to fetch accounts");
            return BadRequest();
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateAccountRequest request)
    {
        var entity = _builder
            .SetBalance(request.Amount)
            .SetCurrency(request.Currency)
            .SetType(request.Type)
            .SetBankIntegration(BankType.None)
            .SetLastModifiedDate(DateTime.UtcNow)
            .Build();
        try
        {
            await _accountService.Add(entity);
            _logger.LogInformation($"Account {entity.Id} successfully created");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create account with id={entity.Id}");
            return BadRequest();
        }
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateAccountRequest request)
    {
        var entity = _builder
            .SetBalance(request.Amount)
            .SetCurrency(request.Currency)
            .SetType(request.Type)
            .SetLastModifiedDate(DateTime.UtcNow)
            .SetBankIntegration(request.BankType)
            .Build();

        try
        {
            await _accountService.Update(entity);
            _logger.LogInformation($"Account {entity.Id} successfully updated");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to update account with id={entity.Id}");
            return BadRequest();
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult> Remove(string id)
    {
        try 
        {
            await _accountService.Remove(id);
            _logger.LogInformation($"Account {id} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete account with id={id}");
            return BadRequest();
        }
    }
}