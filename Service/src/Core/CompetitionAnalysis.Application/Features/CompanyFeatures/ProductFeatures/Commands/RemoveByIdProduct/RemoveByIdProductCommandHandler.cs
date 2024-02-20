//using CompetitionAnalysis.Application.Messaging;
//using CompetitionAnalysis.Application.Services;
//using CompetitionAnalysis.Application.Services.CompanyServices;
//using CompetitionAnalysis.Domain.CompanyEntities;
//using Newtonsoft.Json;
//namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveByIdProduct;
//public sealed class RemoveByIdProductCommandHandler : ICommandHandler<RemoveByIdProductCommand, RemoveByIdProductCommandResponse>
//{
//    private readonly IProductService _service;
//    private readonly ILogService _logService;
//    private readonly IApiService _apiService;
//    public RemoveByIdProductCommandHandler(IProductService service, ILogService logService, IApiService apiService)
//    {
//        _service = service;
//        _logService = logService;
//        _apiService = apiService;
//    }
//    public async Task<RemoveByIdProductCommandResponse> Handle(RemoveByIdProductCommand request, CancellationToken cancellationToken)
//    {
//        Product product = await _service.RemoveByIdProductAsync(request.Id, request.companyId);
//        string userId = _apiService.GetUserIdByToken();
//        Log log = new()
//        {
//            Id = Guid.NewGuid().ToString(),
//            TableName = nameof(Product),
//            Progress = "Delete",
//            Data = JsonConvert.SerializeObject(product),
//            UserId = userId
//        };

//        await _logService.AddAsync(log, request.companyId);

//        return new();
//    }
//}