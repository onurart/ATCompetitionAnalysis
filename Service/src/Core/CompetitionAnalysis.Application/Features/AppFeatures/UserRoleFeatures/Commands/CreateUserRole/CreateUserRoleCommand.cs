using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.UserRoleFeatures.Commands.CreateUserRole;
public sealed record CreateUserRoleCommand(string RoleId, string UserId) : ICommand<CreateUserRoleCommandResponse>;