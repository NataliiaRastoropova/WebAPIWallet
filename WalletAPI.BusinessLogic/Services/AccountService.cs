using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;

namespace WalletAPI.BusinessLogic.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task<IReadOnlyList<AccountDto>> Get()
    {
        var accounts = await _accountRepository.Get();
        if (accounts == null)
            return new List<AccountDto>();
        
        return  accounts.Select(e => new AccountDto(
            id: e.Id, 
            type: e.Type, 
            amount: e.Amount, 
            currency: e.Currency, 
            lastModified: e.LastModified)).ToList().AsReadOnly();
    }
    
    public async Task<AccountDto> Get(string id)
    {
        var account = await _accountRepository.Get(id);
        if (account == null)
            return AccountDto.Default;

        return new AccountDto(
            id: account.Id, 
            type: account.Type, 
            amount: account.Amount, 
            currency: account.Currency, 
            lastModified: account.LastModified);
    }

    public async Task Add(AccountDto account)
    {
        if (account == AccountDto.Default)
            return;

        await _accountRepository.Create(new AccountEntity
        {
            Id = account.Id,
            Amount = account.Amount,
            Type = account.Type,
            Currency = account.Currency,
            LastModified = DateTime.UtcNow,
        });
    }
    
    public async Task Update(AccountDto account)
    {
        if (account == AccountDto.Default)
            return;
        
        await _accountRepository.Update(new AccountEntity
            {
                Id = account.Id,
                Amount = account.Amount,
                Type = account.Type,
                Currency = account.Currency,
                LastModified = DateTime.UtcNow,
            });
    }
    
    public async Task Remove(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            throw new ArgumentNullException();
        
        await _accountRepository.Delete(id);
    }
}