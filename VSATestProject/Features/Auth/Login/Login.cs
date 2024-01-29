using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Services;

public static class Login
{
    public class LoginRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
    
    public class LoginHandler
    {
        private readonly ApplicationContext _appContext;

        private readonly GenerateSession.SessionHandler _sessionHandler;
    
        private readonly CredentialsCheckService _credentialsCheckService;

        private readonly PasswordHasherService _passwordHasherService;
    

        public LoginHandler(ApplicationContext appContext,
            GenerateSession.SessionHandler sessionHandler, PasswordHasherService passwordHasherService, CredentialsCheckService credentialsCheckService)
        {
            _appContext = appContext;
            _sessionHandler = sessionHandler;
            _passwordHasherService = passwordHasherService;
            _credentialsCheckService = credentialsCheckService;
        }

        public async Task<UserSession> HandleAsync(LoginRequest loginRequest)
        {
            var passwordHash = _passwordHasherService.Md5HashPassword(loginRequest.Password);

            var user = await _appContext.Accounts
                .FirstOrDefaultAsync(x => x.Login == loginRequest.Login && x.PasswordHash == passwordHash);

            if (user is null)
            {
                throw new CustomException(["Проверьте правильность введенных данных."], "Произошла ошибка", 401);
            }
            var session = _sessionHandler.Handle(user);
            user.Sessions.Add(session);
            await _appContext.SaveChangesAsync();
            return session;
        }
    }
    
   
    
   
}