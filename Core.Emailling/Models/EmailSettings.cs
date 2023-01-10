namespace Core.Emailling.Models;

public class EmailSettings
{
    public string? Server { get; set; }
    public int Port { get; set; }
    public string? SenderName { get; set; }
    public string? Host { get; set; }
    public string? SenderEmail { get; set; }
    public string? Password { get; set; }
    public bool? AuthenticationRequired { get; set; }

    public EmailSettings()
    {
        AuthenticationRequired = false;

    }
    public EmailSettings(string? server, int port, string? senderName, string? senderEmail, string? password, bool? authenticationRequired = false)
    {
        Server = server;
        Port = port;
        SenderName = senderName;
        SenderEmail = senderEmail;
        Password = password;
        AuthenticationRequired = authenticationRequired;
    }
}
