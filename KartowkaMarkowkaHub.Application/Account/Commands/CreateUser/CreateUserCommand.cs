using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid?>
    {
        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
