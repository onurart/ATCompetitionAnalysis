using CompetitionAnalysis.Application.Messaging;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand
{
    public sealed record GetAllBrandQuery(string CompanyId):IQuery<GetAllBrandQueryResponse>;
}
