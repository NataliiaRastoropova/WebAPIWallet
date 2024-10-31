using Microsoft.Extensions.Logging;

namespace WalletAPI.BusinessLogic.TemplateMethod;

public abstract class WalletTransaction
{
    protected ILogger Logger;
    
    protected WalletTransaction(ILoggerFactory loggerFactory)
    {
        Logger = loggerFactory.CreateLogger(typeof(WalletTransaction));
    }

    // Шаблонний метод
    public void ProcessTransaction(decimal amount)
    {
        ValidateTransaction(amount);
        DeductAmount(amount);
        if (HasFees())
        {
            ApplyFees(amount);
        }
        NotifyUser();
    }

    // Загальні методи
    protected void ValidateTransaction(decimal amount)
    {
        Logger.LogInformation($"Validating transaction for amount: {amount}");
    }

    protected abstract void DeductAmount(decimal amount);

    protected virtual bool HasFees()
    {
        return false; // За замовчуванням без комісії
    }

    protected virtual void ApplyFees(decimal amount)
    {
        // Для транзакцій з комісією
    }

    protected void NotifyUser()
    {
        Logger.LogInformation("Transaction complete. Notifying user...");
    }
}