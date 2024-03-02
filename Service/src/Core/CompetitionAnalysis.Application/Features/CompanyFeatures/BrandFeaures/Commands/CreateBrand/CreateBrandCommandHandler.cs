using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand
{
    public sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, CreateBrandCommandResponse>
    {
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        private readonly IBrandService _service;

        public CreateBrandCommandHandler(ILogService logService, IApiService apiService, IBrandService service)
        {
            _logService = logService;
            _apiService = apiService;
            _service = service;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand createBrand = await _service.CreateBrandAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Brand),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(createBrand)
            };
            await _logService.AddAsync(log, request.companyId);
            return new();
        }
    }
}
