using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.AppDbContext.MainRoleReporistories
{
    public interface IMainRoleQueryRepository : IQueryGenericRepository<MainRole>
    {
    }
}
