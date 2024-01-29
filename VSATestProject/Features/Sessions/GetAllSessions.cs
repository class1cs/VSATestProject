using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Sessions;

public static class GetAllSessions
{
    public class GetAllSessionsHandler
    {
        private readonly ApplicationContext _applicationContext;
        public GetAllSessionsHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<UserSession>> HandleAsync()
        {
            var sessions = await _applicationContext.UserSessions.ToListAsync();
            return sessions;
        }
    }
}