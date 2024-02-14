using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;

namespace CompetitionAnalysis.Domain.Repositories.AppDbContext.UserRoleRepositories
{
    public interface IUserRoleQueryRepository : IAppQueryRepository<AppUserRole>
    {
    }
}
