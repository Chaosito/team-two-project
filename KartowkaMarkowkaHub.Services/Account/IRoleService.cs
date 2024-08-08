using KartowkaMarkowkaHub.DTO.Account;

namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAll();
    }
}