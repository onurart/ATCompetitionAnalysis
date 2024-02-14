using CompetitionAnalysis.Domain.AppEntities.Identity;
namespace CompetitionAnalysis.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetUserRoles;
public sealed record GetUserRolesQueryResponse(IList<AppUserRole> AppUserRoles);