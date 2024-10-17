using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.BusinessLogic.Services;

namespace WalletAPI.BusinessLogic.Strategy;

//Стратегія поповнення через банківський рахунок
public class BankDepositStrategy : IDepositStrategy
{
    public void Deposit(Account account, decimal amount)
    {
        // Add logic "Depositing {amount} via Bank Account..
        account.UpdateBalance(amount);
    }
}