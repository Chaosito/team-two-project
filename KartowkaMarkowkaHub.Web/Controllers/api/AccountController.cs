using KartowkaMarkowkaHub.DTO.Account;
using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) 
        {
            _userService = userService;
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
    }
}
