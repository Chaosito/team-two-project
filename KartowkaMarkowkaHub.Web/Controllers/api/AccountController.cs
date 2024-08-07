using KartowkaMarkowkaHub.DTO.Account;
using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Services.Identity;
using KartowkaMarkowkaHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AccountController(IUserService userService, IAuthService authService) 
        {
            _userService = userService;
            _authService = authService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel user)
        {
            var userDto = new UserDTO()
            {
                Email = user.Email,
                Login = user.Login,
                Name = user.UserName,
                Password = user.Password,
            };

            var result = await _userService.CreateAsync(userDto);

            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login(UserViewModel user)
        {
            var userDto = _authService.Login(user.Login, user.Password);
            if (userDto == null) return Unauthorized();

            return Ok(userDto);
        }

        [Authorize]
        [HttpGet("TestAuth")]
        public IActionResult TestAuth()
        {
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpGet("TestAuthRole")]
        public IActionResult TestAuthRole()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("TestAuthAnonymous")]
        public IActionResult TestAuthAnonymous()
        {
            return Ok(new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }
    }
}
