using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetUserRoles;
public sealed record GetUserRolesQuery(string UserId) : IQuery<GetUserRolesQueryResponse>;