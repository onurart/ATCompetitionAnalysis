using CompetitionAnalysis.Domain.AppEntities;
namespace CompetitionAnalysis.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
public sealed record GetAllCompanyQueryResponse(List<Company> Companies);