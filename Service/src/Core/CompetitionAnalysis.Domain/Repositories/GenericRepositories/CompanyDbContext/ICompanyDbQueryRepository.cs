using CompetitionAnalysis.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbQueryRepository<T> : ICompanyDbRepository<T>, IQueryGenericRepository<T> where T : Entity
    {
    }
}
