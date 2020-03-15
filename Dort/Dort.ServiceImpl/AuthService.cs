using Dort.Repository.Db;
using Dort.Service;
using Dort.Utils;
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
        private readonly IUserRepository _userRepository;
        private readonly byte[] _loginTokenKey;
        private readonly string _passordTokenKey;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _loginTokenKey = Encoding.ASCII.GetBytes(config.GetSection("loginTokenKey").Value);
            _passordTokenKey = config.GetSection("passwordKey").Value;
        }

        public DateTime GetTokenExpirationTime()
        {
            return DateTime.Now.AddYears(1);
        }

        public async Task<string> Authenticate(string email, string password)
        {
            try
            {
                var passEncrypted = Cryptography.Encrypt(password, _passordTokenKey);
                Entity.User user = await _userRepository.FindOne(new { email, password = passEncrypted });

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_loginTokenKey), SecurityAlgorithms.HmacSha256Signature),
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
