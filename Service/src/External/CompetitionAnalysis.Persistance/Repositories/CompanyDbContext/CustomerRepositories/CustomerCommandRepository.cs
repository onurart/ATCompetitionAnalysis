using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CustomerRepositories
{
    public class CustomerCommandRepository : CompanyDbCommandRepository<Customer>, ICustomerCommandRepository
    {
    }
}
