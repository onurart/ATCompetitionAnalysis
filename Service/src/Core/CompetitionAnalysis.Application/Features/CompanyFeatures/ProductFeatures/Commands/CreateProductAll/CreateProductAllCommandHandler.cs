using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.AppServices;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductAll;
public sealed class CreateProductAllCommandHandler : ICommandHandler<CreateProductAllCommand, CreateProductAllCommandResponse>
{
    private readonly IProductService _service;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;
    private readonly ICompanyService _companyService;

    public CreateProductAllCommandHandler(IProductService service, ILogService logService, IApiService apiService, ICompanyService companyService)
    {
        _service = service;
        _logService = logService;
        _apiService = apiService;
        _companyService = companyService;
    }

    public async Task<CreateProductAllCommandResponse> Handle(CreateProductAllCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateProductAll(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Log log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(Product),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject("")
        };
        await _logService.AddAsync(log, "");
        return new();
    }
}