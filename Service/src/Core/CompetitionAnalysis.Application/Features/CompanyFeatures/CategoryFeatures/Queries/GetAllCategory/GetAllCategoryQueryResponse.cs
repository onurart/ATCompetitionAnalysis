using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory
{
    public sealed record GetAllCategoryQueryResponse(IList<Category> Data);

}
