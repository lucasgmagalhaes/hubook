using Dort.Service;
using Dort.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _auth;

        public AccountController(IUserService userService, IAuthService auth)
        {
            _auth = auth;
            _userService = userService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult> Create(NewUserModel user)
        {
            await _userService.Create(user.Name, user.Email, user.Password);
            await _auth.Authenticate(user.Email, user.Password);
            return Ok("User registered succesfuly");
        }

        [Authorize]
        [HttpPost("update")]
        public async Task<ActionResult> UpdateProfile(UpdateUserProfileModel model)
        {
            await _userService.UpdateProfile(model.Name, model.Password, model.ProfileImgUrl);
            return Ok("Profile updated");
        }
    }
}
