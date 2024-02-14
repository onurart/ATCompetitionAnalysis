using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
public sealed record GetAllRolesQueryResponse(IList<AppRole> Roles);