using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.MainRoleReporistories;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.AppDbContext.MainRoleRepositories
{
    public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
    {
        public MainRoleCommandRepository(Context.AppDbContext context) : base(context) { }
    }
}
