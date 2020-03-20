using Dort.Entity;
using Dort.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dort.ServiceImpl
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpAcessor;
        private readonly byte[] _loginTokenKey;
       
        public AuthService(IUserService userService, 
            IConfiguration config,
            IHttpContextAccessor httpAcessor)
        {
            _userService = userService;
            _httpAcessor = httpAcessor;
            _loginTokenKey = Encoding.ASCII.GetBytes(config.GetSection("loginTokenKey").Value);
        }

        public DateTime GetTokenExpirationTime()
        {
            return DateTime.Now.AddYears(1);
        }

        public async Task Authenticate(string email, string password)
        {
            User user = await _userService.FindByEmailAndPassword(email, password);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_loginTokenKey), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                NotBefore = DateTime.Now,
                Expires = GetTokenExpirationTime()
            });

            CookieOptions option = new CookieOptions
            {
                Expires = GetTokenExpirationTime(),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "127.0.0.1"
            };

            var token = handler.WriteToken(securityToken);
            _httpAcessor.HttpContext.Response.Cookies.Append("SessionId", token, option);
        }
    }
}
