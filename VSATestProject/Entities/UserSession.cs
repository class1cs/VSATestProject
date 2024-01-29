namespace VSATestProject.Entities;

public class UserSession
{
    public UserSession(DateTime expires, string token)
    {
        Expires = expires;
        Token = token;
    }

    public Guid Id { get; set; }
    
    public string Token { get; set; }
    
    public DateTime Expires { get; set; }
    
    public Guid AccountId { get; set; }
    
    
}