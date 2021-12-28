namespace DomainPrimitive.Domain.Model.User;

public class Username
{
    private string name;

    public static implicit operator Username(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException();
        }

        return new Username { name = str };
    }

    public static implicit operator string(Username username) => username.name;
}
