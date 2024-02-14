using CompetitionAnalysis.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbRepository<T> : IRepository<T> where T : Entity
    {
        void SetDbContextInstance(DbContext context);
    }
}
