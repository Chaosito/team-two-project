using KartowkaMarkowkaHub.Application.Abstractions.Common.Models;
using KartowkaMarkowkaHub.Services.Roles;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Roles.Queries.GetAllRoles
{
    internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Response<RolesViewModel>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response<RolesViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAll();
            var roleViewModels = roles
                .Select(x => new RoleViewModel() { Id = x.Id, Name = x.Name, Descriptions = x.Description }).ToList();

            var result = new RolesViewModel { Roles = roleViewModels };
            return new Response<RolesViewModel> { Result = result };
        }
    }
}
