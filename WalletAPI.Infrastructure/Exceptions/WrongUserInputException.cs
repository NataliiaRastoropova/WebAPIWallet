namespace WalletAPI.Infrastructure.Exceptions;

public class WrongUserInputException : Exception
{
    public WrongUserInputException()
    {
        
    }
    public WrongUserInputException(string typeName) : base(typeName)
    {
        
    }
}