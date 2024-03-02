using CompetitionAnalysis.Domain.Dtos;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationshipQueryDto
{
    public sealed record ProductCustomerRelationshipQueryResponseDto(IList<ProductCustomerRelationshipDto> Data);

}
