using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.ChainOfResponsibility.TransactionHandling;
using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.ChainOfResponsibility.ValidationHandling;

public class EmailValidationHandler : Handler<User>
{
    public EmailValidationHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    
    public void Validate(User user)
    {
        if (!user.Email.Contains("@"))
        {
            throw new Exception("Invalid email format.");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(user);
        }
    }
}