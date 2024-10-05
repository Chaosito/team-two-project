namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDTO>> GetAll();


        Task<UserDTO> GetUserByIdAsync(Guid Id);

        Task<UserDTO> CreateAsync(CreateUserDTO user);

        Task<UserDTO> AddRoleUserAsync(Guid userId, Guid roleId);
    }
}