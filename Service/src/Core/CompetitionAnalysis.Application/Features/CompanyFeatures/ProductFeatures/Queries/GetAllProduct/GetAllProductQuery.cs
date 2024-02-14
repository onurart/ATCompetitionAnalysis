using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;
public sealed record GetAllProductQuery(string CompanyId) : IQuery<GetAllProductQueryResponse>;