using KartowkaMarkowkaHub.Application.Account.Commands.AddUserRole;
using KartowkaMarkowkaHub.Application.Account.Commands.CreateUser;
using KartowkaMarkowkaHub.Application.Account.Commands.LoginUser;
using KartowkaMarkowkaHub.Application.Account.Queries.GetAllUsers;
using KartowkaMarkowkaHub.Application.Account.Queries.GetUser;
using KartowkaMarkowkaHub.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var viewModels = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);

            return Ok(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
        {
            var viewModels = await _mediator.Send(new GetUserQuery { Id = id }, cancellationToken);

            return Ok(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest request, CancellationToken cancellationToken)
        {
            Guid? id = await _mediator.Send(new CreateUserCommand 
            {
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Roles = request.Roles.Select(i => new CreateUserRole
                {
                    Description = i.Description,
                    Id = i.Id,
                    Name = i.Name,
                }),
            }, cancellationToken);

            if (id is null) return BadRequest();

            var viewModel = await _mediator.Send(new GetUserQuery { Id = id.Value }, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            var viewModel = await _mediator.Send(new LoginUserCommand 
            { 
                Login = request.Login,
                Password = request.Password,
            }, cancellationToken);

            return Ok(viewModel);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleUserRequest request, CancellationToken cancellationToken)
        {
            var viewModel = await _mediator.Send(new AddUserRoleCommand
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
            }, cancellationToken);

            return Ok(viewModel);
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
