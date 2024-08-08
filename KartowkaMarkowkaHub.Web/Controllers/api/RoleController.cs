using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var roles = await _roleService.GetAll();
            var result = roles.Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Descriptions = x.Description });
            return Ok(result);
        }
    }
}
