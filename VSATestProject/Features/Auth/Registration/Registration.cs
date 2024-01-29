using System.Security.Authentication;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Services;

public static class Registration
{

    public class RegistrationRequest
    {

            public string Name { get; set; }
    
            public string SecondName { get; set; }

            public string Patronymic { get; set; }
    
            public string Login { get; set; }
    
            public string Password { get; set; }
    
            public string ConfirmPassword { get; set; }
    }
    public class RegistrationHandler
    {
        private readonly ApplicationContext _appContext;
        private readonly GenerateSession.SessionHandler _sessionHandler;
        private readonly PasswordHasherService _passwordHasherServiceService;
        private readonly CredentialsCheckService _credentialsCheckService;

        public RegistrationHandler(ApplicationContext appContext, CredentialsCheckService credentialsCheckService,
            GenerateSession.SessionHandler sessionHandler, PasswordHasherService passwordHasherServiceService)
        {
            _passwordHasherServiceService = passwordHasherServiceService;
            _appContext = appContext;
            _credentialsCheckService = credentialsCheckService;
            _sessionHandler = sessionHandler;
        }

        public async Task<UserSession> HandleAsync(Registration.RegistrationRequest registrationRequest)
        {
            var hash = _passwordHasherServiceService.Md5HashPassword(registrationRequest.Password);
            var userToAdd = new User()
            {
                Id = new Guid(),
                Name = registrationRequest.Name,
                SecondName = registrationRequest.SecondName,
                Patronymic = registrationRequest.Patronymic,
                PasswordHash = hash,
                Login = registrationRequest.Login
            };
            if (!_credentialsCheckService.CheckPasswordMatch(registrationRequest.Password, registrationRequest.ConfirmPassword))
            {
                throw new CustomException(["Пароли не совпадают!"], "Произошла ошибка", 409);
            }
            if (await _credentialsCheckService.CheckUserExistsAsync(userToAdd.Login))
            {
                throw new CustomException(["Пользователь уже существует. Измените логин и попробуйте снова."], "Произошла ошибка", 409);
            }
            var createdUser = await _appContext.Users.AddAsync(userToAdd);
            var session = _sessionHandler.Handle(userToAdd);
            createdUser.Entity.Sessions.Add(session);
            await _appContext.SaveChangesAsync();
            return session;
        }
    }
    
   
}