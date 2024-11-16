using KartowkaMarkowkaHub.Application.Account.Queries.GetAllUsers;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Account.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public Guid Id { get; set; }
    }
}
