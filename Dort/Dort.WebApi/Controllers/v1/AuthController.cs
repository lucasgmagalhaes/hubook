using Dort.Services;
using Dort.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Login(LoginModel model)
        {
            try
            {
                string token = _auth.Authenticate(model.Email, model.Password);

                CookieOptions option = new CookieOptions
                {
                    Expires = _auth.GetTokenExpirationTime(),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    Domain = "localhost"
                };

                Response.Cookies.Append("SessionId", token, option);

                return Ok(new RequestResponse() { Content = "Sucess" });
            }
            catch
            {
                return BadRequest("Invalid Email or password");
            }
        }
    }
}
