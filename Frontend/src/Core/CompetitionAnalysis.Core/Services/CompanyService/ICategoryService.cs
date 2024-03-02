using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface ICategoryService
    {
        Task<bool> CreateCaegory(CreateCategory request, string token);
        Task<List<GetAllCategory>> GetAllCategoriesAsync(string companyId, string token);
    }
}
