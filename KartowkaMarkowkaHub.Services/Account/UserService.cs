using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.DTO.Account;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        
        public UserService(IRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAllQueryable().Include(x => x.Roles).ThenInclude(x => x.Role).Select(x => new UserDTO(x)).ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid Id)
        {
            var user = await _userRepository.FindByCondition(x => x.Id == Id)
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .Select(user => new UserDTO(user))
                .FirstOrDefaultAsync();

            //if(user == null)
            //{
            //    throw new UserException("Такой пользователь не найден", new Exception("Ошибка"), 1001);
            //}

            return user;
        }

        public async Task<UserDTO> CreateAsync(UserDTO user)
        {

            var userSample = new User()
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
            };

            var result = await _userRepository.AddAsync(userSample);

            return new UserDTO()
            {
                Id = result.Id,
                Email = result.Email,
                Login = result.Login
            };
        }

        public async Task<UserDTO> AddRoleUserAsync(Guid userId, Guid roleId)
        {
            var user = await _userRepository.FindByCondition(x => x.Id == userId).Include(x => x.Roles).ThenInclude(x => x.Role).AsTracking().FirstOrDefaultAsync();
            user.Roles.Add(new UserRole() { RoleId = roleId, UserId = userId });

            await _userRepository.UpdateAsync(user);

            var result = await _userRepository.FindByCondition(x => x.Id == userId).Include(x => x.Roles).ThenInclude(x => x.Role).FirstOrDefaultAsync();

            return new UserDTO(result);
        }
    }
}
