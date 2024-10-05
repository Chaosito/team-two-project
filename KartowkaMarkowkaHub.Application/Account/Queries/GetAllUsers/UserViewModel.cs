namespace KartowkaMarkowkaHub.Application.Account.Queries.GetAllUsers
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<RoleViewModel> Roles { get; set; }
    }

    public class RoleViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
