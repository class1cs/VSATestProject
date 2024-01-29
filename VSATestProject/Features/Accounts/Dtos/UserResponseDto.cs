using VSATestProject.Entities;

namespace VSATestProject.Features.Users.Responses;

public class UserResponseDto
{
    public UserResponseDto(User user)
    {
        Id = user.Id;
        Login = user.Login;
        PasswordHash = user.PasswordHash;
        Name = user.Name;
        SecondName = user.SecondName;
        Patronymic = user.Patronymic;
        Balance = user.Balance;
    }

    public Guid Id { get; set; }
    
    public string Login { get; set; }

    public string PasswordHash { get; set; }
    
    public string Name { get; set; }
    
    public string SecondName { get; set; }
    
    public string Patronymic { get; set; }
    
    public decimal Balance { get; set; }
    
    
}