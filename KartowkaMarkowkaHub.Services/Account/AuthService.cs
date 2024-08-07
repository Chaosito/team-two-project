using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;
using KartowkaMarkowkaHub.Services.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;
        
        public AuthService(IRepository<User> userRepository, ITokenService tokenService)
        {
                _userRepository = userRepository;
                _tokenService = tokenService;
        }

        public async Task<LoginDto> Login(string username, string password)
        {
            var user = await _userRepository
                    .FindByCondition(x => x.Login == username && x.Password == password)
                    .FirstOrDefaultAsync();

            if (user == null) return null;

            var token = await _tokenService.TokenGenerateAsync(user.Id);

            return new LoginDto() { AccessToken = token, Login = username };
        }
    }
}
