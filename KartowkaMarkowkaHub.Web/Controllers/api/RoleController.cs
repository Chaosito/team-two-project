using KartowkaMarkowkaHub.Application.Roles.Queries.GetAllRoles;
using KartowkaMarkowkaHub.Services.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRoleService _roleService;
        
        public RoleController(IMediator mediator, IRoleService roleService)
        {
            _mediator = mediator;
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) 
        {
            var query = new GetAllRolesQuery();
            var viewModel = await _mediator.Send(query, cancellationToken);
            return Ok(viewModel);
        }
    }
}
