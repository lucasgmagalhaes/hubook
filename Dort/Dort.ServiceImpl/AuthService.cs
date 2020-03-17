using Dort.Entity;
using Dort.Service;
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
        private readonly byte[] _loginTokenKey;

        public AuthService(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _loginTokenKey = Encoding.ASCII.GetBytes(config.GetSection("loginTokenKey").Value);
        }

        public DateTime GetTokenExpirationTime()
        {
            return DateTime.Now.AddYears(1);
        }

        public async Task<string> Authenticate(string email, string password)
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

            return handler.WriteToken(securityToken);
        }
    }
}
