using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.AddUserRole
{
    public class AddUserRoleCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
