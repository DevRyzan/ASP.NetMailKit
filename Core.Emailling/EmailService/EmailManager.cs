using Core.Emailling.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text; 

namespace Core.Emailling.EmailService;

public class EmailManager: IEmailService
{
    private readonly EmailSettings _emailSettings;
    public EmailManager(IConfiguration configuration)
    {
        _emailSettings = configuration.GetSection("MailSettings").Get<EmailSettings>();

    }
    public void SendEmail(Email request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings.SenderEmail, _emailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
    public async void SendEmailAsync(Email request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.SenderEmail));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings.SenderEmail, _emailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}
