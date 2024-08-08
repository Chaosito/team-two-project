using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;

namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();


        Task<UserDTO> GetUserByIdAsync(Guid Id);

        Task<UserDTO> CreateAsync(UserDTO user);

        Task<UserDTO> AddRoleUserAsync(Guid userId, Guid roleId);
    }
}