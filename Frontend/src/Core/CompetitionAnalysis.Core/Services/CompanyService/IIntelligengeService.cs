using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship.Commands;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface IIntelligengeService
    {
        Task<bool> CreateIntelligenge(CreateProductCustomerRelationshipCommand request, string token);

    }
}
