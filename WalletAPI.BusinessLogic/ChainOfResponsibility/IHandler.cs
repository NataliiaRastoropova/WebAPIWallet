using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;

public interface IHandler<T>
{
    IHandler<T> SetNext(IHandler<T> handler);
    void Handle(T request);
}