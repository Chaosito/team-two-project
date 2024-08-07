using KartowkaMarkowkaHub.DTO.Account;

namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IAuthService
    {
        Task<LoginDto> Login(string username, string password);
    }
}