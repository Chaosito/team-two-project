using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Services.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IClaimService _claimService;

        public TokenService(IClaimService claimService)
        {
            _claimService = claimService;
        }

        public async Task<string> TokenGenerateAsync(Guid id)
        {
            var claims = await _claimService.GetAllClaims(id);

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

