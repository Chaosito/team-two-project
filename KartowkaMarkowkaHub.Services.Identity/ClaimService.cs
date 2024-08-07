using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.Identity
{
    public class ClaimService : IClaimService
    {
        private readonly IRepository<User> _userRepository;
        //private readonly IRepository<UserRole> _userRoleRepository;

        public ClaimService(IRepository<User> userRepository
            //, IRepository<UserRole> userRoleRepository)
            )
        {
            _userRepository = userRepository;
            //_userRoleRepository = userRoleRepository;
        }

        public async Task<List<Claim>> GetRoleClaims(Guid userId)
        {
            //var result = await _userRoleRepository.FindByCondition(x => x.UserId == userId)
            //    .Include(x => x.Role)
            //    .Select(x => new Claim(ClaimTypes.Role, x.Role.Name)).ToListAsync();

            var result = await _userRepository.GetByIdAsync(userId);
            var r = _userRepository.GetAllQueryableAsync()
                .Include(f => f.Roles).ThenInclude(y => y.Role)
                .FirstOrDefault(x => x.Id == userId);

            var roles = r.Roles.Select(x => x.Role);

            return roles.Select(x => new Claim(ClaimTypes.Role, x.Name)).ToList();
        }

        public async Task<List<Claim>> GetAllClaims(Guid userId)
        {
            var roleClaims = await GetRoleClaims(userId) ?? new List<Claim>();
            
            var user = await _userRepository.GetByIdAsync(userId);
            List<Claim> userInfo = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login)
            };

            userInfo.AddRange(roleClaims);

            return userInfo;
        }
    }
}
