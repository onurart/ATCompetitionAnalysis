using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories
{
    public class MainRoleAndUserRelationshipCommandRepository : AppCommandRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelationshipCommandRepository
    {
        public MainRoleAndUserRelationshipCommandRepository(Persistance.Context.AppDbContext context) : base(context) { }
    }
}
