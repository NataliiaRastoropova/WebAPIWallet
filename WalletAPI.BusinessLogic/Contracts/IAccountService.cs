using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Contracts;

public interface IAccountService
{
    Task<IReadOnlyList<AccountDto>> Get();
    Task<AccountDto> Get(string id);
    Task Add(AccountDto account);
    Task Update(AccountDto account);
    Task Remove(string id);
}