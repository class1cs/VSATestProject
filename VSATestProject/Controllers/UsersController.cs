using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Dtos;
using VSATestProject.Entities;
using VSATestProject.Features.Users;
using VSATestProject.Features.Users.Responses;
using VSATestProject.Services;

namespace VSATestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;
        private readonly RemoveUser.RemoveUserHandler _removeUserHandler;
        private readonly GetUser.GetAccountHandler _getAccountHandler;
        private readonly GetAllUsers.GetAllUsersHandler _getAllUsersHandler;
        private readonly EditUser.EditUserHandler _editUserHandler;

        public UsersController(ApplicationContext applicationContext, RemoveUser.RemoveUserHandler removeUserHandler, GetUser.GetAccountHandler getAccountHandler, GetAllUsers.GetAllUsersHandler getAllUsersHandler, EditUser.EditUserHandler editUserHandler)
        {
            _applicationContext = applicationContext;
            _removeUserHandler = removeUserHandler;
            _getAccountHandler = getAccountHandler;
            _getAllUsersHandler = getAllUsersHandler;
            _editUserHandler = editUserHandler;

        }
        
        [HttpPut("edit")]
        public async Task<IActionResult> Edit(Guid userId, [FromBody] EditUser.EditUserRequest editUserRequest)
        {
            await _editUserHandler.HandleAsync(userId, editUserRequest);
            return Ok(new BaseResponse($"Пользователь успешно отредактирован.", Array.Empty<string>()));
        }
        
        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _getAccountHandler.HandleAsync(userId);
            return Ok(new BaseResponse<UserResponseDto>($"Пользователь {user.Login}.", user, Array.Empty<string>()));
        }
        
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _getAllUsersHandler.HandleAsync();
            return Ok(new BaseResponse<List<UserResponseDto>>($"Список всех пользователей.", users, Array.Empty<string>()));
        }
        
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(Guid userId)
        {
            await _removeUserHandler.HandleAsync(userId);
            return Ok(new BaseResponse($"Пользователь успешно удален.", Array.Empty<string>()));
        }
    }
}
