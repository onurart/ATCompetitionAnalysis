﻿using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace CompetitionAnalysis.Domain.Repositories.CompanyDbContext.BrandRepositories
{
    public interface IBrandCommandRepository: ICompanyDbCommandRepository<Brand>
    {
    }
}