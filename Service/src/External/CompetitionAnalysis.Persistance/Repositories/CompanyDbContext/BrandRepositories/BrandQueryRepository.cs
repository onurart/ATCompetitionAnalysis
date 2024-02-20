using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.BrandRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.BrandRepositories
{
    public class BrandQueryRepository : CompanyDbQueryRepository<Brand>,IBrandQueryRepository
    {
    }
}
