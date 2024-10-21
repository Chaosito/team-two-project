namespace KartowkaMarkowkaHub.Services.Account
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAll();


        Task<GetUserDto> GetUserByIdAsync(Guid Id);

        Task<UserDto> CreateAsync(CreateUserDto user);

        Task<UserDto> AddRoleUserAsync(Guid userId, Guid roleId);
    }
}