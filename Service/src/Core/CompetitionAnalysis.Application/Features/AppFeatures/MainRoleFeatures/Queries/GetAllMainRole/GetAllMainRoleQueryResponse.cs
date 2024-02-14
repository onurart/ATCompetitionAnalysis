using CompetitionAnalysis.Domain.AppEntities;
namespace CompetitionAnalysis.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
public sealed record GetAllMainRoleQueryResponse(IList<MainRole> MainRoles);