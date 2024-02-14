using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.Dtos;

namespace CompetitionAnalysis.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<TokenRefreshTokenDto> CreateTokenAsync(AppUser user);
    }
}
