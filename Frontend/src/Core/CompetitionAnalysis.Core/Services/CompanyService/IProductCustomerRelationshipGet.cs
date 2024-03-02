using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface IProductCustomerRelationshipGet
    {
        Task<List<GetProductCustomerRelationship>> GetAlGetProductCustomerRelationshipAsync(string companyId, string token);

    }
}
