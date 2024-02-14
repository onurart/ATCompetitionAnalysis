using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.AppEntities.Identity;

namespace CompetitionAnalysis.Application.Services.AppServices
{
    public interface IAuthService
    {
        Task<AppUser> GetByEmailOrUserNameAsync(string emailOrUserName);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<AppUser> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword);
        Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string userId);
        Task<string> GetMainRolesByUserId(string userId);
    }
}
