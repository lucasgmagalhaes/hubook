using Dort.Entity;
using Dort.Repository.Db;
using Dort.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult<RequestResponse> Register(UserModel user)
        {
            _userRepository.Insert(new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });

            return Login(user);
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public ActionResult<RequestResponse> Login(UserModel user)
        {
            var appUser = _userRepository.FindByEmailndPassword(user.Email, user.Password);

            if(appUser == null)
            {
                BadRequest("Email or Password invalid");
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                     new GenericIdentity(appUser.Name, "Login"),
                     new[] 
                     {
                        new Claim(JwtRegisteredClaimNames.Jti, appUser.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Name)
                     }
                 );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = DateTime.Now.AddYears(1);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SigningConfigurations signingConfigurations = new SigningConfigurations();

            SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "",
                Audience = "",
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            string token = handler.WriteToken(securityToken);

            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost"
            };

            Response.Cookies.Append("SessionId", token, option);

            return Ok(new RequestResponse() { Content = "Sucess" });
        }
    }
}
