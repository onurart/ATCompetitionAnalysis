using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Quert
{
    public sealed record GetAllCustomerQueryResponse(IList<CustomerModel> Data);
}
