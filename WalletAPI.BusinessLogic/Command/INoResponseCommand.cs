namespace WalletAPI.BusinessLogic.Command;

public interface INoResponseCommand<in TInput>
{
    void Execute(TInput data);
}