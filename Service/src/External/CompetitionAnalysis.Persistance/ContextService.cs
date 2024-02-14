using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
