namespace WalletAPI.BusinessLogic.TemplateMethod.DataSync;

//Abstract Class(Template)
public abstract class DataSynchronizer
{
    public void Synchronize()
    {
        OpenSource();
        OpenDestination();
        TransferData();
        CloseSource();
        CloseDestination();
    }
    protected abstract void OpenSource();
    protected abstract void OpenDestination();
    protected abstract void TransferData();
    protected abstract void CloseSource();
    protected abstract void CloseDestination();
}