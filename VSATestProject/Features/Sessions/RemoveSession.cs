using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Exceptions;

namespace VSATestProject.Features.Sessions;

public static class RemoveSession
{
    public class RemoveSessionHandler
    {
        private readonly ApplicationContext _applicationContext;
        public RemoveSessionHandler(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }
        public async Task HandleAsync(Guid sessionId)
        {
            try
            {
                var sessionToDelete = await _applicationContext.UserSessions.FirstOrDefaultAsync(x => x.Id == sessionId);
                if (sessionToDelete is null)
                {
                    throw new CustomException(["Сессия не найдена."], "Произошла ошибка", 500);
                } 
                _applicationContext.UserSessions.Remove(sessionToDelete);
                await _applicationContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new CustomException(["Неизвестная ошибка."], "Произошла ошибка", 500);
            }
        }
    }
}