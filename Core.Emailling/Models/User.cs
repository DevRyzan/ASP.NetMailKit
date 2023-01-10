namespace Core.Emailling.Models;

public class User
{
    public int Id { get; set; }
    public string? NickName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }  
    public User()
    { 
    }

    public User(int id, string? nickName, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status) : this()
    {
        Id = id;
        NickName = nickName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status; 
    }
}
