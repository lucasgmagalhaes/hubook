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
using WebApi.Security;

namespace WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public ActionResult<RequestResponse> Create(NewUserModel user)
        {
            _userRepository.Insert(new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });

            return Ok("User registered succesfuly");
        }
    }
}
