using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface IProductCustomerRelationshipGet
    {
        Task<List<GetProductCustomerRelationship>> GetAlGetProductCustomerRelationshipAsync(string companyId);

    }
}
