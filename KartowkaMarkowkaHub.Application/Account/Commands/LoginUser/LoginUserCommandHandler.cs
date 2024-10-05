using KartowkaMarkowkaHub.Services.Account;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginViewModel>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserLoginViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(request.Login, request.Password);

            return new UserLoginViewModel 
            { 
                AccessToken = result.AccessToken,
                Login = result.Login,
            };
        }
    }
}
