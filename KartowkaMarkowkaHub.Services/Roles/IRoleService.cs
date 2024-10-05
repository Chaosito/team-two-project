namespace KartowkaMarkowkaHub.Services.Roles
{
    public interface IRoleService
    {
        Task<IEnumerable<GetRoleDTO>> GetAll();
    }
}