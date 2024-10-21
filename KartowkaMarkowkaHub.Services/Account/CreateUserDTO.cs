namespace KartowkaMarkowkaHub.Services.Account
{
    public class CreateUserDto
    {
        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
