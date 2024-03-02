using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(CreateBrandCommand requset, CancellationToken cancellationToken);
        Task<IList<Brand>> GetAllBrandsAsync(string companyId);
    }
}
