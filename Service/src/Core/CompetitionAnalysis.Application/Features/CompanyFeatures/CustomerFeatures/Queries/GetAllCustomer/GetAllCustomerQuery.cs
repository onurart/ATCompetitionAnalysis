using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
public sealed record GetAllCustomerQuery(string CompanyId) : IQuery<GetAllCustomerQueryResponse>;