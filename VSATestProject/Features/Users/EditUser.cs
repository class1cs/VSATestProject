using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Users;

public static class EditUser
{
    public class EditUserRequest
    {
        public string Name { get; set; }
    
        public string SecondName { get; set; }
    
        public string Patronymic { get; set; }
        
        public string Login { get; set; }
        
        public decimal Balance { get; set; }
    }
    
    public class EditUserHandler
    {
        private readonly ApplicationContext _applicationContext;
        private readonly GetUser.GetAccountHandler _getAccountHandler;

        public EditUserHandler(ApplicationContext applicationContext, GetUser.GetAccountHandler getAccountHandler)
        {
            _applicationContext = applicationContext;
            _getAccountHandler = getAccountHandler;
        }
        public async Task HandleAsync(Guid userId, EditUserRequest editUserRequest)
        {
            var userToEdit = await _applicationContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (userToEdit is null)
            {
                throw new CustomException(["Пользователь не найден"], "Произошла ошибка", 500);
            }
            var users = _applicationContext.Users.Where(x => x.Login != userToEdit.Login);
            var isLoginExists = await users.AnyAsync(x => x.Login == editUserRequest.Login);
            if (isLoginExists)
            {
                throw new CustomException(["Пользователь с данным логином уже существует."], "Произошла ошибка", 409);
            }
            userToEdit.Name = editUserRequest.Name;
            userToEdit.Login = editUserRequest.Login;
            userToEdit.SecondName = editUserRequest.SecondName;
            userToEdit.Patronymic = editUserRequest.Patronymic;
            userToEdit.Balance = editUserRequest.Balance;
            await _applicationContext.SaveChangesAsync();
        }
    }
}