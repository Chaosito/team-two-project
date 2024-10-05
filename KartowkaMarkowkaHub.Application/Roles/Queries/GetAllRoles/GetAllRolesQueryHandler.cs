using KartowkaMarkowkaHub.Services.Roles;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Roles.Queries.GetAllRoles
{
    internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, RolesViewModel>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RolesViewModel> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAll();
            var roleViewModels = roles
                .Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Descriptions = x.Description }).ToList();

            return new RolesViewModel { Roles = roleViewModels };
        }
    }
}
