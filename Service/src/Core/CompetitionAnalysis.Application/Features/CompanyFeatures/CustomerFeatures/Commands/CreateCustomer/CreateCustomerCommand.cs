using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
public sealed record CreateCustomerCommand
                                          (
                                            string Name,
                                            string companyId) : ICommand<CreateCustomerCommandResponse>;