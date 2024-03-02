using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public  interface IBrandRepository
    {
        Task<bool> CreateBrand(CreateBrandCommand request ,string token);
        Task<List<GetAllBrandQueryResponse>> GetAllBrand(string companyId, string token);



    }
}
