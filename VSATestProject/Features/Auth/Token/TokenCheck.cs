using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Exceptions;

namespace VSATestProject.Services;

public static class TokenCheck
{
    public class TokenCheckHandler
    {
        public async Task HandleAsync(HttpContext context, string token, ApplicationContext applicationContext)
        {
            if (token == null)
            {
                return;
            }
            var userId = context.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            if (userId is null)
            {
                throw new CustomException(["Проверьте правильность токена."], "Произошла ошибка.", 500);
            }
            Guid userGuidId = Guid.Parse(userId);
        
            var user = await applicationContext.Accounts.FirstOrDefaultAsync(x => x.Id == userGuidId);
            if (!applicationContext.UserSessions.Any(x => x.Token == token))
            {
                throw new CustomException(["Сессия недействительна."], "Произошла ошибка.", 401);
            }
        }
    }
}