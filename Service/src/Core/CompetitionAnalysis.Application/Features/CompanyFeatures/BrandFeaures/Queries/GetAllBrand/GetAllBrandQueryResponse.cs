using CompetitionAnalysis.Domain.CompanyEntities;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand
{
    public sealed record GetAllBrandQueryResponse(IList<Brand> Data);
    
}
