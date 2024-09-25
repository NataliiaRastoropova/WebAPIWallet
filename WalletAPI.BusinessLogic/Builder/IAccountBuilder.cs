using WalletAPI.BusinessLogic.Dtos;
using WalletAPI.Infrastructure.Enums;

namespace WalletAPI.BusinessLogic.Builder;

//Паттерн Builder дозволяє створювати складні об'єкти поетапно.
//У проєкті з темою "Wallet" цей паттерн можна використовувати для побудови складного об'єкта гаманця,
//який може мати різні параметри (назва гаманця, тип валюти, баланс, дата створення, банківська інтеграція тощо).
public interface IAccountBuilder
{
    IAccountBuilder SetId(string id);
    IAccountBuilder SetBalance(decimal balance);
    IAccountBuilder SetType(AccountType name);
    IAccountBuilder SetCurrency(CurrencyType currency);
    IAccountBuilder SetLastModifiedDate(DateTime date);
    IAccountBuilder SetBankIntegration(BankType bankIntegration);
    Account Build();
}