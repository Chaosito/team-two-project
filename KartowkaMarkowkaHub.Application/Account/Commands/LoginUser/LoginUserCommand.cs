using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserLoginViewModel>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class UserLoginViewModel : IRequest<bool>
    {
        public string Login { get; set; }
        public string AccessToken { get; set; }
    }
}
