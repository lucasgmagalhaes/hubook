using Dort.Service;
using Dort.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<ActionResult> Create(NewUserModel user)
        {
            await _userService.Create(user.Name, user.Email, user.Password);
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
