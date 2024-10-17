using System.Collections;
using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Enumerator;

public class TransactionCollection : IEnumerable<Transaction>
{
    private List<Transaction> _transactions = new List<Transaction>();

    // Додавання транзакції в колекцію
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // Реалізація методу GetEnumerator для підтримки foreach
    public IEnumerator<Transaction> GetEnumerator()
    {
        return new TransactionEnumerator(_transactions);
    }

    // Неявна реалізація IEnumerable
    
    // Підтримка foreach і старих API: Коли ви використовуєте foreach для ітерації
    // через об'єкти, компілятор завжди шукає метод GetEnumerator. Якщо колекція реалізує IEnumerable<T>,
    // компілятор використовує типізовану версію для безпечної ітерації через конкретні типи. Але для сумісності
    // з більш ранніми версіями .NET та API,
    // які працюють з нетипізованими колекціями, також потрібна реалізація неявної версії IEnumerable.GetEnumerator().
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}