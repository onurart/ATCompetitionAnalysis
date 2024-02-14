using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContextNoEntity
{
    public interface ICompanyDbRepository2<T> : IRepository2<T> where T : class
    {
        void SetDbContextInstance(DbContext context);
    }
}
