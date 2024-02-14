using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.ProductRepositories
{
    public sealed class ProductQueryRepository : CompanyDbQueryRepository<Product>, IProductQueryRepository
    {
    }
}
