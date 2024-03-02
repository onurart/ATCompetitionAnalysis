using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CampaignRepository
{
    public interface ICampaignCommandRepository : ICompanyDbCommandRepository<Campaign>
    {
    }
}
