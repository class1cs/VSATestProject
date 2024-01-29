using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSATestProject.Dtos;
using VSATestProject.Services;

namespace VSATestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Login.LoginHandler _loginHandler;
        private readonly Registration.RegistrationHandler _registrationHandler;
        public AuthController(Login.LoginHandler loginHandler, Registration.RegistrationHandler registrationHandler)
        {
            _loginHandler = loginHandler;
            _registrationHandler = registrationHandler;
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] Login.LoginRequest loginRequest)
        {
            var session = await _loginHandler.HandleAsync(loginRequest);
            return Ok(new BaseResponse<string>( "Успешный вход!", session.Token, Array.Empty<string>()));
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] Registration.RegistrationRequest registrationRequest)
        {
            var session = await _registrationHandler.HandleAsync(registrationRequest);
            return Ok(new BaseResponse<string>( "Успешная регистрация.", session.Token, Array.Empty<string>()));
        }
    }
}
