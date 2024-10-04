using WalletAPI.BusinessLogic.FactoryMethod.Banks;

namespace WalletAPI.BusinessLogic.FactoryMethod.Factories;

// Переваги використання паттерну Factory Method

// Гнучкість та розширюваність: Для додавання підтримки нового банку
// достатньо реалізувати новий клас інтеграції та відповідну фабрику, не змінюючи існуючий код.

// Інкапсуляція логіки: Вся логіка створення об'єктів для різних банків ізольована
// у фабриках, що спрощує підтримку та оновлення.

// Підтримка різних API: Кожен банк може мати власну специфіку API,
// і цей паттерн дозволяє обробляти такі випадки, не порушуючи загальну архітектуру.
public abstract class BankIntegrationFactory
{
    public abstract IBankIntegration CreateBankIntegration();
    
    // fabric method
    public void BankSync(DateTime startDate, DateTime endDate)
    {
        IBankIntegration bank = CreateBankIntegration();
        bank.GetTransactions(startDate, endDate);
    }
}