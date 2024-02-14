using CompetitionAnalysis.Domain.CompanyEntities;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;
public sealed record GetAllProductQueryResponse(IList<Product> Data);