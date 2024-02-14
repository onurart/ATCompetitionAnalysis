using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.AppServices;
namespace CompetitionAnalysis.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
public sealed class RemoveByIdUserAndCompanyRLCommandHandler : ICommandHandler<RemoveByIdUserAndCompanyRLCommand, RemoveByIdUserAndCompanyRLCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _service;
    public RemoveByIdUserAndCompanyRLCommandHandler(IUserAndCompanyRelationshipService service)
    {
        _service = service;
    }
    public async Task<RemoveByIdUserAndCompanyRLCommandResponse> Handle(RemoveByIdUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoveByIdAsync(request.Id);
        return new();
    }
}