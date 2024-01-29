using VSATestProject.Entities;

namespace VSATestProject.Features.Users.Responses;

public class AdminResponseDto
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }

    public string PasswordHash { get; set; }

    public AdminResponseDto(Administrator administrator)
    {
        Login = administrator.Login;
        PasswordHash = administrator.PasswordHash;
    }
}