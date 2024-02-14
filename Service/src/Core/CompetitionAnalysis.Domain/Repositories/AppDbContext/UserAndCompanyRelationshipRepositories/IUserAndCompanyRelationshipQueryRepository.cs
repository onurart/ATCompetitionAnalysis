using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;

namespace CompetitionAnalysis.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories
{
    public interface IUserAndCompanyRelationshipQueryRepository : IAppQueryRepository<UserAndCompanyRelationship>
    {
    }
}
