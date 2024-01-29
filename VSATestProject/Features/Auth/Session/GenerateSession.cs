using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using VSATestProject.Data_Access_Layer;
using VSATestProject.Entities;

namespace VSATestProject.Services;

public static class GenerateSession
{
    public class SessionHandler
    {
        private readonly ApplicationContext _appContext;

        public SessionHandler(ApplicationContext appContext) => _appContext = appContext;

        public UserSession Handle(Account account)
        {
            string role = account.GetType().Name;
            var claims = new List<Claim>();
            claims.Add(new(ClaimTypes.Role, role));
            claims.Add(new("Id", account.Id.ToString()));

            var expirationTime = DateTime.UtcNow.Add(TimeSpan.FromDays(5));
            var jwt = new JwtSecurityToken(AuthOptions.Issuer,
                AuthOptions.Audience,
                claims,
                expires: expirationTime,
                signingCredentials: new(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return new UserSession(expires: expirationTime, token: encodedJwt);
        }
    }
}