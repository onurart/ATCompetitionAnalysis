using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appContext;
        public ContextService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }

    }
}
