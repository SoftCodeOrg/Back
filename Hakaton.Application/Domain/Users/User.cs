using System.Text.Json.Serialization;

namespace Hakaton.Application.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    
    [JsonIgnore]
    public bool isAdmin { get; set; }

    public User(
        string username,
        string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        isAdmin = false;
    }
}