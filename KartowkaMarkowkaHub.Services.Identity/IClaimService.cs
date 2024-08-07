using System.Security.Claims;

namespace KartowkaMarkowkaHub.Services.Identity
{
    public interface IClaimService
    {
        Task<List<Claim>> GetAllClaims(Guid userId);
    }
}