using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;
using VSATestProject.Features.Users.Responses;

namespace VSATestProject.Features.Users;

public static class GetAllUsers
{
    public class GetAllUsersHandler
    {
        private readonly ApplicationContext _applicationContext;

        public GetAllUsersHandler(ApplicationContext dbContext)
        {
            _applicationContext = dbContext;
        }
        public async Task<List<UserResponseDto>> HandleAsync()
        {
            return await _applicationContext.Users.Select(x => new UserResponseDto(x)).ToListAsync();
        }
    }
}