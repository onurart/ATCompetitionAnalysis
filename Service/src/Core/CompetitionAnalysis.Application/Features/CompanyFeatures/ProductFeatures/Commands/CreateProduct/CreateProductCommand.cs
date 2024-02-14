using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
public sealed record CreateProductCommand(string Name, decimal Price, string companyId) : ICommand<CreateProductCommandResponse>;