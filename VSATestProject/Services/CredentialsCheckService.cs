using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;

namespace VSATestProject.Services;

public class CredentialsCheckService
{
    private readonly ApplicationContext _appContext;

    private readonly PasswordHasherService _passwordHasherServiceService;

    public CredentialsCheckService(ApplicationContext applicationContext,
        PasswordHasherService passwordHasherServiceService)
    {
        _appContext = applicationContext;
        _passwordHasherServiceService = passwordHasherServiceService;
    }

    public Task<bool> CheckUserExistsAsync(string login)
    {
        return _appContext.Users.AnyAsync(x => x.Login == login);
    }
    
    public bool CheckPasswordMatch(string password, string confirmPassword)
    {
        return confirmPassword == password;
    }
}