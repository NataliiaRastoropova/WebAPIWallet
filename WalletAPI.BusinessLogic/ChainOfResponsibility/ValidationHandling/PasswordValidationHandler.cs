using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.ValidationHandling;

public class PasswordValidationHandler : Handler<User>
{
    public PasswordValidationHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    public void Validate(User user)
    {
        if (user.Password.Length < 6)
        {
            throw new Exception("Password must be at least 6 characters long.");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(user);
        }
    }
}