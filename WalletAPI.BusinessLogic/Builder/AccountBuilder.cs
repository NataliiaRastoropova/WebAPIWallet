using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.DataAccess.Repositories.Account;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Builder;

public class AccountBuilder : IAccountBuilder
{
    private string? _id;
    private decimal _amount;
    private AccountType _type;
    private CurrencyType _currency;
    private DateTime _lastModified;
    private BankType _bankType;

    public IAccountBuilder SetId(string id)
    {
        _id = id;
        return this;
    }
    
    public IAccountBuilder SetBalance(decimal balance)
    {
        _amount = balance;
        return this;
    }

    public IAccountBuilder SetType(AccountType type)
    {
        _type = type;
        return this;
    }

    public IAccountBuilder SetCurrency(CurrencyType currency)
    {
        _currency = currency;
        return this;
    }

    public IAccountBuilder SetLastModifiedDate(DateTime date)
    {
        _lastModified = date;
        return this;
    }

    public IAccountBuilder SetBankIntegration(BankType bankIntegration)
    {
        _bankType = bankIntegration;
        return this;
    }

    public Account Build()
    {
        return new Account(
            id: _id ?? Guid.NewGuid().ToString(),
            amount: _amount,
            type: _type,
            currency: _currency,
            lastModified: _lastModified,
            bankType: _bankType
        );
    }
}