using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
public sealed class GetAllCustomerQueryHandler : IQueryHandler<GetAllCustomerQuery, GetAllCustomerQueryResponse>
{
    private readonly ICustomerService _service;

    public GetAllCustomerQueryHandler(ICustomerService service)
    {
        _service = service;
    }
    public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        return new(await _service.GetAllAsync(request.CompanyId));
    }
}