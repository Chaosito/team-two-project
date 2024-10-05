using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<GetRoleDTO>> GetAll()
        {
            var result = await _roleRepository.GetAllAsync();
            return result.Select(x => new GetRoleDTO() { Id = x.Id, Name = x.Name, Description = x.Description });
        }
    }
}
