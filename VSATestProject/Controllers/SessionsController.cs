using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Features.Sessions;
using VSATestProject.Features.Users;
using VSATestProject.Features.Users.Responses;

namespace VSATestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class SessionsController : ControllerBase
    { 
        private readonly ApplicationContext _applicationContext;
        private readonly GetSession.GetSessionHandler _getSessionHandler;
        private readonly GetAllSessions.GetAllSessionsHandler _getAllSessionsHandler;
        private readonly RemoveSession.RemoveSessionHandler _removeSessionHandler;

        public SessionsController(ApplicationContext applicationContext, 
            GetSession.GetSessionHandler getSessionHandler,
            GetAllSessions.GetAllSessionsHandler getAllSessionsHandler, 
            RemoveSession.RemoveSessionHandler removeSessionHandler)
        {
            _applicationContext = applicationContext;
            _getSessionHandler = getSessionHandler;
            _getAllSessionsHandler = getAllSessionsHandler;
            _removeSessionHandler = removeSessionHandler;
        }
        
        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid sessionId)
        {
            var session = await _getSessionHandler.HandleAsync(sessionId);
            return Ok(new BaseResponse<UserSession>($"Сессия найдена.", session, Array.Empty<string>()));
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _getAllSessionsHandler.HandleAsync();
            return Ok(new BaseResponse<List<UserSession>>($"Список всех сессий.", sessions, Array.Empty<string>()));
        }
        
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(Guid sessionId)
        {
            await _removeSessionHandler.HandleAsync(sessionId);
            return Ok(new BaseResponse($"Сессия успешно удалена.", Array.Empty<string>()));
        }
    }
}
