using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;
public sealed record CreateStaticRolesCommand() : ICommand<CreateStaticRolesCommandResponse>;