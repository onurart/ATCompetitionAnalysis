using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
public sealed record UpdateProductCommand(string Id, string Name, bool IsActive, bool IsDelete, string companyId) : ICommand<UpdateProductCommandResponse>;