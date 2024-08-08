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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();

            var usersViewModel = users.Select(x => new UserViewModel() { Id = x.Id, 
                Login = x.Login, 
                Roles = x.Roles
                        .Select(x => new RoleViewModel() { 
                            Id = x.Id, 
                            Name = x.Name, 
                            Descriptions = x.Description }), 
                Email = x.Email });

            return Ok(usersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id) 
        {
            var result = await _userService.GetUserByIdAsync(Id);

            if(result == null) return NotFound();

            var viewmodel = new UserViewModel()
            {
                Id = Id,
                Login = result.Login,
                Email = result.Email,
                Roles = result.Roles.Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Descriptions = x.Description })
            };

            return Ok(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel user)
        {
            var userDto = new UserDTO()
            {
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
            };

            var result = await _userService.CreateAsync(userDto);

            var userViewModel = new UserViewModel()
            {
                Id = result.Id,
                Login = result.Login,
                Email = result.Email
            };

            return Ok(userViewModel);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var loginDto = await _authService.Login(user.Login, user.Password);

            if (loginDto == null) return Unauthorized();

            var loginViewModel = new LoginViewModel()
            {
                Login = loginDto.Login,
                AccessToken = loginDto.AccessToken
            };

            return Ok(loginViewModel);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleUserViewModel roleUser)
        {
            var user = await _userService.AddRoleUserAsync(roleUser.UserId, roleUser.RoleId);

            return Ok(user);
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
            return Ok();
        }
    }
}
