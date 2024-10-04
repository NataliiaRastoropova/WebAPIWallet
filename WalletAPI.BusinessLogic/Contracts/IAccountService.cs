using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Contracts;

public interface IAccountService
{
    Task<IReadOnlyList<Account>> Get();
    Task<Account> Get(string id);
    Task Add(Account account);
    Task Update(Account account);
    Task Remove(string id);
}