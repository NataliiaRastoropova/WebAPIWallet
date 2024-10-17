using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Strategy;

public interface IDepositStrategy
{
    void Deposit(Account account, decimal amount);
}