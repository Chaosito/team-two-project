﻿using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Commands.LoginUser
{
    public class UserLoginViewModel : IRequest<bool>
    {
        public string Login { get; set; }
        public string AccessToken { get; set; }
    }
}
