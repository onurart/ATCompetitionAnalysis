using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CategoryRepository;
using CompetitionAnalysis.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CategoryRepository
{
    public class CategoryQueryRepository: CompanyDbQueryRepository<Category>,ICategoryQueryRepository
    {
    }
}
