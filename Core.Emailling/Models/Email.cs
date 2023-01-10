namespace Core.Emailling.Models;

public class Email
{
    public string? To { get; set; } = string.Empty;
    public string? Subject { get; set; } = string.Empty;
    public string? Body { get; set; } = string.Empty;
    public Email()
    {

    }
    public Email(string? to, string? subject, string? body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }
}
