using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Strategy;

//Стратегія поповнення через кредитну карту
public class CreditCardDepositStrategy: IDepositStrategy
{
    public void Deposit(Account account, decimal amount)
    {
        // Add logic "Depositing {amount} via Credit Card..
        account.UpdateBalance(amount);
    }
}