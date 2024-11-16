using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KartowkaMarkowkaHub.Application.Account.Queries.GetAllUsers
{
    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, UsersViewModel>
    {
        private readonly IRepository<User> _userRepository;

        public GetAllUserQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersViewModel> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllQueryable()
               .Include(x => x.Roles).ThenInclude(x => x.Role)
               .Select(x => new UserViewModel
               {
                   Email = x.Email,
                   Id = x.Id,
                   Login = x.Login,
                   Password = x.Password,
                   Roles = x.Roles.Select(role => new RoleViewModel() 
                   { 
                       Id = role.Role.Id, 
                       Name = role.Role.Name, 
                       Description = role.Role.Description 
                   }),
               }).ToListAsync();

            return new UsersViewModel { Users = users };
        }
    }
}
