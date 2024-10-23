using WalletAPI.BusinessLogic.DomainModel;

namespace WalletAPI.BusinessLogic.Contracts;

public interface IUserService
{
    public void ValidateUser(User user);
}