using Dort.Service;
using Dort.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dort.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService authService)
        {
            _auth = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model)
        {
            string token = await _auth.Authenticate(model.Email, model.Password);

            CookieOptions option = new CookieOptions
            {
                Expires = _auth.GetTokenExpirationTime(),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "127.0.0.1"
            };

            Response.Cookies.Append("SessionId", token, option);

            return Ok("Sucess");
        }
    }
}
