using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository
{
    public class UserAndCompanyRelationshipQueryRepository : AppQueryRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipQueryRepository
    {
        public UserAndCompanyRelationshipQueryRepository(Persistance.Context.AppDbContext context) : base(context) { }
    }
}
