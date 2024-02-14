using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.AppDbContext.UserRoleRepositories
{
    public interface IUserRoleCommandRepository : IAppCommandRepository<AppUserRole>
    {
    }
}
