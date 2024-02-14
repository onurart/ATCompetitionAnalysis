using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
public sealed record UpdateCustomerCommand(string Id, string Name, string companyId) : ICommand<UpdateCustomerCommandResponse>;