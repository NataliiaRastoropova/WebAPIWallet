namespace WalletAPI.BusinessLogic.FactoryMethod.Banks;

public interface IBankIntegration
{
    string GetBankName();
    void GetTransactions(DateTime startDate, DateTime endDate);
}