using Core.Emailling.EmailService;
using Core.Emailling.Models;
using MediatR;
using System.Security.Cryptography;

namespace Core.Emailling.EmailSender;

public class EmailSender : IEmailSender
{
    private readonly IEmailService _emailService;
    private readonly IEmailService _emailAuthenticatorRepository;

    public EmailSender(IEmailService emailService, IEmailService emailAuthenticatorRepository)
    {
        _emailService = emailService;
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
    }

    public async Task SendAuthenticatorCode(User user)
    {
        await sendAuthenticatorCodeWithEmail(user);
    }
    private async Task<Unit> sendAuthenticatorCodeWithEmail(User user)
    {
        EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);

        if (!emailAuthenticator.IsVerified) throw new BusinessException("Email Authenticator must be is verified.");

        string authenticatorCode = await CreateEmailActivationCode();
        //string authenticatorCode = "123123";
        emailAuthenticator.ActivationKey = authenticatorCode;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

        _emailService.SendEmail(new Email
        {
            To = user.Email,
            Subject = "Subject",
            Body = $"Enter your authenticator code: {authenticatorCode}"
        });
        return Unit.Value;
    }
    public Task<string> CreateEmailActivationKey()
    {
        string key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        return Task.FromResult(key);
    }

    public Task<string> CreateEmailActivationCode()
    {
        string code = RandomNumberGenerator.GetInt32(100000, Convert.ToInt32(Math.Pow(10, 6))).ToString().PadLeft(6, '0');
        return Task.FromResult(code);
    }
}
