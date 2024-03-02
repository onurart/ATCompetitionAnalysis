using CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Product
{
    public sealed record  GetAllProductQueryResponse(IList<ProductModel> Data);
 
}
