namespace KartowkaMarkowkaHub.Web.Models
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }
        
        public string Login { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
