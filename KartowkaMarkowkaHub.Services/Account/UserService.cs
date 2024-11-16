using AutoMapper;
using FluentValidation;
using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Services.Roles;
using Microsoft.EntityFrameworkCore;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<CreateUserDto>> _сreateUserDtoValidators;

        public UserService(IEnumerable<IValidator<CreateUserDto>> сreateUserDtoValidators, IRepository<User> userRepository,
            IMapper mapper) 
        {
            _сreateUserDtoValidators = сreateUserDtoValidators;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUserDto>> GetAll()
        {
            var users = await _userRepository.GetAllQueryable()
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .Select(x => new GetUserDto
                {
                    Id = x.Id,
                    Login = x.Login,
                    Email = x.Email,
                    Roles = x.Roles.Select(role => new GetRoleDTO() { Id = role.Role.Id, Name = role.Role.Name, Description = role.Role.Description }),
                }).ToListAsync();

            return users;
        }

        public async Task<GetUserDto> GetUserByIdAsync(Guid Id)
        {
            var user = await _userRepository
                .FindByCondition(x => x.Id == Id)
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .Select(user => new GetUserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    Roles = user.Roles.Select(role => new GetRoleDTO() { Id = role.Role.Id, Name = role.Role.Name, Description = role.Role.Description }),
                })
                .FirstOrDefaultAsync();

            //if(user == null)
            //{
            //    throw new UserException("Такой пользователь не найден", new Exception("Ошибка"), 1001);
            //}

            return user;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto userDto)
        {
            var validationContext = new ValidationContext<CreateUserDto>(userDto);
            var failures = _сreateUserDtoValidators
               .Select(v => v.Validate(validationContext))
               .SelectMany(result => result.Errors)
               .Where(failure => failure != null)
               .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            User user = _mapper.Map<User>(userDto);

            var result = await _userRepository.AddAsync(user);

            return new UserDto()
            {
                Id = result.Id,
                Email = result.Email,
                Login = result.Login
            };
        }

        public async Task<UserDto> AddRoleUserAsync(Guid userId, Guid roleId)
        {
            var user = await _userRepository
                .FindByCondition(x => x.Id == userId)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role).AsTracking().FirstOrDefaultAsync();
            user.Roles.Add(new UserRole() { RoleId = roleId, UserId = userId });

            await _userRepository.UpdateAsync(user);

            var result = await _userRepository.FindByCondition(x => x.Id == userId).Include(x => x.Roles).ThenInclude(x => x.Role).FirstOrDefaultAsync();

            return new UserDto(result);
        }
    }
}
