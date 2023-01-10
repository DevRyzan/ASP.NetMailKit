using Core.Emailling.Models;

namespace Core.Emailling.EmailSender;

public interface IEmailSender
{
    Task SendAuthenticatorCode(User user);
    Task<string> CreateEmailActivationKey();
    Task<string> CreateEmailActivationCode();

}
