using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CategoryRepository
{
    public interface ICategoryQueryRepository: ICompanyDbQueryRepository<Category>
    {
    }
}
