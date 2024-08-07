namespace KartowkaMarkowkaHub.Services.Identity
{
    public interface ITokenService
    {
        Task<string> TokenGenerateAsync(Guid userId);
    }
}