using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Users;

public static class RemoveUser
{
    public class RemoveUserHandler
    {
        private readonly ApplicationContext _applicationContext;
        private readonly GetUser.GetAccountHandler _getAccountHandler;
        
        public RemoveUserHandler(ApplicationContext applicationContext, GetUser.GetAccountHandler getAccountHandler)
        {
            _applicationContext = applicationContext;
            _getAccountHandler = getAccountHandler;

        }
        public async Task HandleAsync(Guid userId)
        {
            try
            {
                var user = await _applicationContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user is null)
                {
                    throw new CustomException(["Пользователь не найден."], "Произошла ошибка", 500);
                }
                _applicationContext.Users.Remove(user);
                await _applicationContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new CustomException(["Неизвестная ошибка."], "Произошла ошибка", 500);
            }
        }
    }

}