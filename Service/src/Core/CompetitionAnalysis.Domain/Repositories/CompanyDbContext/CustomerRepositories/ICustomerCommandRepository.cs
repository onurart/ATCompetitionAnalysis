using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories
{
    public interface ICustomerCommandRepository : ICompanyDbCommandRepository<Customer>
    {
    }
}
