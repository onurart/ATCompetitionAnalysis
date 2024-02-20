using CompetitionAnalysis.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand
{
    public sealed record GetAllBrandQuery(string CompanyId):IQuery<GetAllBrandQueryResponse>;
}
