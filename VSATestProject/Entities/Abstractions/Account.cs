namespace VSATestProject.Entities;

public abstract class Account
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }

    public string PasswordHash { get; set; }

    public List<UserSession> Sessions { get; set; } = new();

}