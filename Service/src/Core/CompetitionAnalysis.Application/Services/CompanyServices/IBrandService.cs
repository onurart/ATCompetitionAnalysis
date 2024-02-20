using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Domain.CompanyEntities;
namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(CreateBrandCommand request, CancellationToken cancellationToken);
        Task<IList<Brand>> GetAllAsync(string companyId);
        //Task UpdateAsync(Brand customer, string companyId);
        //Task<Brand> RemoveByIdBrandAsync(string id, string companyId);
        //Task<Brand> GetByBrandCodeAsync(string companyId, string customercode, CancellationToken cancellationToken);
        //Task<Brand> GetByIdAsync(string id, string companyId);
    }
}
