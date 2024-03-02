using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CustomerRepositories
{
    public class CustomerCommandRepository : CompanyDbCommandRepository<Customer>, ICustomerCommandRepository
    {
    }
}
