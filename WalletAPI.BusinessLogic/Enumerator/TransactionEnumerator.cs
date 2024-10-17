using System.Collections;
using WalletAPI.BusinessLogic.Dtos;

namespace WalletAPI.BusinessLogic.Enumerator;

public class TransactionEnumerator  : IEnumerator<Transaction>
{
    private readonly List<Transaction> _transactions;
    private int _position = -1;

    public TransactionEnumerator(List<Transaction> transactions)
    {
        _transactions = transactions;
    }
    
    public Transaction Current => _transactions[_position];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _transactions.Count;
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Dispose()
    {
        // Немає ресурсів для звільнення
    }
}