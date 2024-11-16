using KartowkaMarkowkaHub.Services.Account;
using KartowkaMarkowkaHub.Services.Roles;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.CreateUser
{
    internal class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid?>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateAsync(new CreateUserDto
            {
                Email = request.Email,
                Login = request.Login,
                Password = request.Password,
            });

            return result.Id;
        }
    }
}
