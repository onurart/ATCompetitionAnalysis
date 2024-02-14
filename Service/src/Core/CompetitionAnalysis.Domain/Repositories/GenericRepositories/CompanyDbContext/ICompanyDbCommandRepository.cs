using CompetitionAnalysis.Domain.Abstractions;
namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbCommandRepository<T> : ICompanyDbRepository<T>, ICommandGenericRepository<T> where T : Entity
    {
    }
}
