using Dort.Repository.Db;
using Dort.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dort.ServiceImpl
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly byte[] loginTokenKey;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            loginTokenKey = Encoding.ASCII.GetBytes(config.GetSection("loginTokenKey").Value);
        }

        public DateTime GetTokenExpirationTime()
        {
            return DateTime.Now.AddYears(1);
        }

        public string Authenticate(string email, string password)
        {
            try
            {
                Entity.User user = _userRepository.FindByEmailndPassword(email, password);

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(loginTokenKey), SecurityAlgorithms.HmacSha256Signature),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Email.ToString())
                    }),
                    NotBefore = DateTime.Now,
                    Expires = GetTokenExpirationTime()
                });

                return handler.WriteToken(securityToken);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
