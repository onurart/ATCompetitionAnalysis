using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
        Task<IList<Category>> GetAllCategoryAsync(string companyId);
    }
}
