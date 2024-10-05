using KartowkaMarkowkaHub.Services.Account;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.AddUserRole
{
    internal class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, bool>
    {
        private readonly IUserService _userService;

        public AddUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.AddRoleUserAsync(request.UserId, request.RoleId);

            return true;
        }
    }
}
