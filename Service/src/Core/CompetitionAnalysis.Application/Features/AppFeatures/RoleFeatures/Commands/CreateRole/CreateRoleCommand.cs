using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
public sealed record CreateRoleCommand(string Code, string Name) : ICommand<CreateRoleCommandResponse>;