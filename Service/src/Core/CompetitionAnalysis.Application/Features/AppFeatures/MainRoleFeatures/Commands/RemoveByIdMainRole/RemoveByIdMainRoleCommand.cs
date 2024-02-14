using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
public sealed record RemoveByIdMainRoleCommand(string Id) : ICommand<RemoveByIdMainRoleCommandResponse>;