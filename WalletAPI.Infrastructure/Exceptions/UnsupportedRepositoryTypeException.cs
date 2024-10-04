namespace WalletAPI.Infrastructure.Exceptions;

public sealed class UnsupportedRepositoryTypeException : Exception
{
    public UnsupportedRepositoryTypeException(string typeName) : base(typeName)
    {
        
    }
}