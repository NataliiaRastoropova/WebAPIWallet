namespace WalletAPI.BusinessLogic.Decorator;

public abstract class WalletDecorator : IWallet
{
    //Inherited from the Base Component Interface
    protected IWallet _wallet;

    //Initializing the Field using Constructor
    //While Creating an instance of the WalletDecorator (Instance of the Child Class that Implements WalletDecorator abstract class)
    //We need to pass the existing  object which we want to decorate
    public WalletDecorator(IWallet wallet)
    {
        _wallet = wallet;
    }

    public virtual void MakePayment(decimal amount)
    {
        _wallet.MakePayment(amount);
    }
}