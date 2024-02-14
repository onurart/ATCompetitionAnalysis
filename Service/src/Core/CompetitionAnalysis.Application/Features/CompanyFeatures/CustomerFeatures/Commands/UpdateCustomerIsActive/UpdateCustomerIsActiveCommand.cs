using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomerIsActive;
public sealed record UpdateCustomerIsActiveCommand(string Id, bool isactive, string companyId) : ICommand<UpdateCustomerIsActiveCommandResponse>;