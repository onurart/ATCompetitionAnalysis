using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContextNoEntity
{
    public interface ICompanyDbQueryRepository2<T> : ICompanyDbRepository2<T>, IQueryGenericRepository2<T> where T : class
    {
    }
}
