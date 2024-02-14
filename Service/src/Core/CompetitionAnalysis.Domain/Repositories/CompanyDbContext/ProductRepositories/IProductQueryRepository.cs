﻿using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories
{
    public interface IProductQueryRepository : ICompanyDbQueryRepository<Product>
    {
    }
}