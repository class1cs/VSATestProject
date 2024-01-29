using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Sessions;

public static class GetSession
{
    public class GetSessionHandler
    {
        private readonly ApplicationContext _applicationContext;
        public GetSessionHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<UserSession> HandleAsync(Guid sessionId)
        {
            var session = await _applicationContext.UserSessions.FirstOrDefaultAsync(x => x.Id == sessionId);
            if (session is null)
            {
                throw new CustomException(["Сессия не найдена."], "Произошла ошибка", 500);
            }
            return session;
        }
    }
}