using Domain.Primitives;

namespace Domain.Shared;

public abstract class User : Entity
{
    private string? Username { get; set; }
    
    private string? Password { get; set; }
    
    private bool? IsBlocked { get; set; }

    protected User(string username, string password)
    {
        Username = username;
        Password = password;
    }


    public void BlockUser()
    {
        IsBlocked = true;
    }
}