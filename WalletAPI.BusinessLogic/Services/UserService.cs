using Microsoft.Extensions.Logging;
using WalletAPI.BusinessLogic.ChainOfResponsibility.ValidationHandling;
using WalletAPI.BusinessLogic.Contracts;
using WalletAPI.BusinessLogic.DomainModel;
using WalletAPI.Infrastructure.Exceptions;

namespace WalletAPI.BusinessLogic.Services;

public class UserService : IUserService
{
    private ILoggerFactory _loggerFactory;

    public UserService(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
    
    public void ValidateUser(User user)
    {
        var emailValidator = new EmailValidationHandler(_loggerFactory);
        var passwordValidator = new PasswordValidationHandler(_loggerFactory);

        emailValidator.SetNext(passwordValidator);

        // Виконуємо валідацію
        try
        {
            emailValidator.Validate(user);
        }
        catch (Exception ex)
        {
            throw new WrongUserInputException($"Validation failed: {ex.Message}");
        }
    }
}