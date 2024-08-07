using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;

namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserDTO user);

        Task<UserDTO> Login(string username, string password);
    }
}