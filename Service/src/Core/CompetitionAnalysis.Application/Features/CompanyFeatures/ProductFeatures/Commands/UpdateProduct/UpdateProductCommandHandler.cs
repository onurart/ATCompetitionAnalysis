using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    private readonly IProductService _service;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;
    public UpdateProductCommandHandler(IProductService service, ILogService logService, IApiService apiService)
    {
        _service = service;
        _logService = logService;
        _apiService = apiService;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _service.GetByIdAsync(request.Id, request.companyId);

        if (product == null) throw new Exception("Ürün bulunamadı!");

        if (product.Name != request.Name)
        {
            Product checkNewCode = await _service.GetByProductCodeAsync(request.companyId, request.Name, cancellationToken);
            if (checkNewCode != null) throw new Exception("Bu ürün kodu daha önce kullanılmış!");
        }
        string userId = _apiService.GetUserIdByToken();
        Log oldLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "UpdateOld",
            TableName = nameof(Product),
            Data = JsonConvert.SerializeObject(product),
            UserId = userId,
        };
        product.Name = request.Name;
        product.IsActive = request.IsActive;
        product.IsDelete = request.IsDelete;

        await _service.UpdateAsync(product, request.companyId);

        Log newLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "UpdateNew",
            TableName = nameof(Product),
            Data = JsonConvert.SerializeObject(product),
            UserId = userId
        };

        await _logService.AddAsync(oldLog, request.companyId);
        await _logService.AddAsync(newLog, request.companyId);

        return new();
    }
}