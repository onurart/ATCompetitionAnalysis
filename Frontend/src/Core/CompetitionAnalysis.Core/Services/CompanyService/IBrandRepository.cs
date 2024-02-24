using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public  interface IBrandRepository
    {
        //Task<bool> CreateBrand(string BrandName, string companyId);
        Task<List<GetAllBrand>> GetAllBrand(string token);


    }
}
