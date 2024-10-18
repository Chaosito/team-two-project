using KartowkaMarkowkaHub.Application.Abstractions.Common.Models;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<Response<RolesViewModel>>
    {

    }
}
