using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProductIsActive;
public sealed record UpdateProductIsActiveCommand(string Id, bool IsActive, string companyId) : ICommand<UpdateProductIsActiveCommandResponse>;