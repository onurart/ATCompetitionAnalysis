using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.GenericRepositories
{
    public interface IRepository2<T> where T : class
    {
        DbSet<T> Entity { get; set; }
    }
}
