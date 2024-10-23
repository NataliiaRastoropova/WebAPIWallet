namespace WalletAPI.BusinessLogic.DomainModel;

public class User : IEquatable<User>
{
    public string Id { get; }
    public string Email { get; }
    public string Password { get; }
    
    public User(string id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public bool Equals(User? other)
    {
        if (other == null)
            return false;
        
        return Id == other.Id && Email == other.Email && Password == other.Password;
        
    }

    public override int GetHashCode()
    {
        return (Id.GetHashCode() + Email.GetHashCode() + Password.GetHashCode()) * 45;
    }
}