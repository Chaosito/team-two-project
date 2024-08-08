using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
                _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            var result = await _roleRepository.GetAllAsync();
            return result.Select(x => new RoleDTO() { Id = x.Id, Name = x.Name, Description = x.Description});
        }
    }
}
