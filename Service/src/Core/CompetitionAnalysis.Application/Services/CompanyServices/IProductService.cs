using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductCompany;
using CompetitionAnalysis.Domain.CompanyEntities;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken);
        Task<IList<Product>> GetAllAsync(string companyId);
        //Task UpdateAsync(Product product, string companyId);
        //Task<Product> RemoveByIdProductAsync(string id, string companyId);
        //Task<Product> UpdateProductIsActiveAsync(string id, string companyId, bool isActive);
        //Task<Product> GetByProductCodeAsync(string companyId, string name, CancellationToken cancellationToken);
        //Task<Product> GetByIdAsync(string id, string companyId);
    }
}
