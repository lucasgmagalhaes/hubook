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
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<RequestResponse> Login()
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
