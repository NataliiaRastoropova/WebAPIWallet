namespace WalletAPI.BusinessLogic.Command;

public interface INoResponseAsyncCommand<in TInput>
{
    Task Execute(TInput data);
}