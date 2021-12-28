using System.Net.Mail;

namespace DomainPrimitive.Domain.Model.User;

public class Email
{
    private string email;

    public static implicit operator Email(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException();
        }

        if (!MailAddress.TryCreate(str, out var _))
        {
            throw new FormatException();
        }

        return new Email { email = str };
    }

    public static implicit operator string(Email email) => email.email;
}