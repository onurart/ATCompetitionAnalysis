using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.UserRoleRepositories;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.AppDbContext.UserRoleRepositories
{
    public sealed class UserRoleQueryRepository : AppQueryRepository<AppUserRole>, IUserRoleQueryRepository
    {
        public UserRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
