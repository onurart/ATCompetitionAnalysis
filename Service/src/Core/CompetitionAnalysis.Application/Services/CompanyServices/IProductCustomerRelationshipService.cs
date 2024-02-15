using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Dtos;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface IProductCustomerRelationshipService
    {
        Task<ProductCustomerRelationshipses> CreateProductCustomerRelationshipAsync(CreateProductCustomerRelationshipCommand request, CancellationToken cancellationToken);
        Task<IList<ProductCustomerRelationshipses>> GetAllAsync(string companyId);
        Task<IList<ProductCustomerRelationshipDto>> GetAllDtoAsync(string companyId);

        //    //Task UpdateAsync(ProductCustomerRelationshipses product, string companyId);
        //    //Task<ProductCustomerRelationshipses> RemoveByIdProductCustomerRelationshiptAsync(string id, string companyId);
        //    //Task<ProductCustomerRelationshipses> GetByIdAsync(string id, string companyId);
    }
}
