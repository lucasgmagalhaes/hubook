using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Login()
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                     new GenericIdentity("lucas", "Login"),
                     new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, "lucas")
                     }
                 );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = DateTime.Now.AddYears(1);

            var handler = new JwtSecurityTokenHandler();
            SigningConfigurations signingConfigurations = new SigningConfigurations();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "",
                Audience = "",
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);

            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost"
            };

            Response.Cookies.Append("SessionId", token, option);

            return Ok("Sucess!");
        }
    }
}
