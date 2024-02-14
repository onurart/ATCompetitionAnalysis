using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveByIdCustomer;
public sealed record RemoveByIdCustomerCommand(string Id, string companyId) : ICommand<RemoveByIdCustomerCommandResponse>;