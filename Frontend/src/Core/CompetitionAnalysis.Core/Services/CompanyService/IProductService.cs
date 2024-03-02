using CompetitionAnalysis.Core.Features.CompanyFeatures.Product;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface IProductService
    {
        Task<List<GetAllProductQueryResponse>> GetAllProductAsync(string companyId,string token);
        Task<bool> CreateProduct(CreateProductModel request, string token);

    }
}
