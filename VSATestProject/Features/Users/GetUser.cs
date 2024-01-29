using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;
using VSATestProject.Features.Users.Responses;

namespace VSATestProject.Features.Users;

public static class GetUser
{
    public class GetAccountHandler
    {
        private readonly ApplicationContext _dbContext;

        public GetAccountHandler(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserResponseDto> HandleAsync(Guid userId)
        {
            var account = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (account is null)
            {
                throw new CustomException(["Пользователь не найден"], "Произошла ошибка", 500);
            }
            return new UserResponseDto(account);
          
        }
    }
}