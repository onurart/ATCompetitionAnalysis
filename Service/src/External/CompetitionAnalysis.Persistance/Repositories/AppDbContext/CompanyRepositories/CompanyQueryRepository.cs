using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.AppDbContext.CompanyRepositories
{
    public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
    {
        public CompanyQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
