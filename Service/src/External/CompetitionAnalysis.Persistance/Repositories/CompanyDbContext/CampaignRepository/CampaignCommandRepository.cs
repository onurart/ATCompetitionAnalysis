using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CampaignRepository;
namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CampaignRepository
{
    public class CampaignCommandRepository : CompanyDbCommandRepository<Campaign>, ICampaignCommandRepository
    {
    }
}
