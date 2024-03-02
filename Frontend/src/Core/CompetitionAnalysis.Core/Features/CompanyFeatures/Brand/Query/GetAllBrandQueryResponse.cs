using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query
{
    public sealed record class GetAllBrandQueryResponse(IList<GetAllBrand> Data);
}