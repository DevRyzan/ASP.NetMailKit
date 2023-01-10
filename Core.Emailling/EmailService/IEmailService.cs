using Core.Emailling.Models;

namespace Core.Emailling.EmailService;

public interface IEmailService
{
    void SendEmail(Email result);
    void SendEmailAsync(Email result);
}
