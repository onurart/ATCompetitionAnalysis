using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveByIdProduct;
public sealed record RemoveByIdProductCommand(string Id, string companyId) : ICommand<RemoveByIdProductCommandResponse>;