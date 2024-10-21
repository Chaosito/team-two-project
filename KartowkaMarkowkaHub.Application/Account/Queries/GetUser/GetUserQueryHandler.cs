using KartowkaMarkowkaHub.Application.Account.Queries.GetAllUsers;
using KartowkaMarkowkaHub.Core.Abstractions.Repositories;
using KartowkaMarkowkaHub.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KartowkaMarkowkaHub.Application.Account.Queries.GetUser
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IRepository<User> _userRepository;

        public GetUserQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAllQueryable()
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
               }).FirstOrDefaultAsync();

            return user;
        }
    }
}
