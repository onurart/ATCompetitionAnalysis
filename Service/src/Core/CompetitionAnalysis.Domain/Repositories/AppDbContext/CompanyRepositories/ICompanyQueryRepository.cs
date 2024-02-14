using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories
{
    public interface ICompanyQueryRepository : IAppQueryRepository<Company>
    {
    }
}
