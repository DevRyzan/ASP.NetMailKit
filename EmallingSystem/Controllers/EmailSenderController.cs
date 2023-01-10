using Core.Emailling.EmailSender;
using Core.Emailling.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmallingSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailSenderController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public EmailSenderController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost]
    public async Task SendEmailAuthenticator()
    {
        var user = new User();
        _emailSender.SendAuthenticatorCode(user);
    }
}
