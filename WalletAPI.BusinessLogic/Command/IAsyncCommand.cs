namespace WalletAPI.BusinessLogic.Command;

public interface IAsyncCommand
{
    Task Execute();
}

public interface IAsyncCommand<TOutput>
{
    Task<TOutput> Execute();
}

public interface IAsyncCommand<in TInput, TOutput>
{
    Task<TOutput> Execute(TInput data);
}