using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.DataAccess;
using WalletAPI.DataAccess.Entities;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.DataAccess.Repositories.Factory;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    // public AccountService(IAccountRepository accountRepository)
    public AccountService(WalletContext context)
    {
        // _accountRepository = accountRepository;
        
        IRepositoryFactory factory = RepositoryFactory.Instance();
        _accountRepository = (IAccountRepository)factory.Instantiate<AccountEntity>(context);
    }
    
    public async Task<IReadOnlyList<Account>> Get()
    {
        var accounts = await _accountRepository.Get();
        if (accounts == null)
            return new List<Account>();
        
        return  accounts.Select(e => new Account(
            id: e.Id, 
            type: e.Type, 
            amount: e.Amount, 
            currency: e.Currency, 
            lastModified: e.LastModified,
            bankType: e.BankType)).ToList().AsReadOnly();
    }
    
    public async Task<Account> Get(string id)
    {
        var account = await _accountRepository.Get(id);
        if (account == null)
            return Account.Default;

        return new Account(
            id: account.Id, 
            type: account.Type, 
            amount: account.Amount, 
            currency: account.Currency, 
            lastModified: account.LastModified,
            bankType: BankType.PrivateBank);
    }

    public async Task Add(Account account)
    {
        if (account == Account.Default)
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
    
    public async Task Update(Account account)
    {
        if (account == Account.Default)
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