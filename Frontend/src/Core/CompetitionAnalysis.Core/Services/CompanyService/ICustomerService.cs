using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Quert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface ICustomerService
    {
        Task<bool> CreateCategory(CreateCustomerCommand request, string token);
        Task<List<GetAllCustomerQueryResponse>> GetAllCustomerAsync(string companyId);

    }
}
