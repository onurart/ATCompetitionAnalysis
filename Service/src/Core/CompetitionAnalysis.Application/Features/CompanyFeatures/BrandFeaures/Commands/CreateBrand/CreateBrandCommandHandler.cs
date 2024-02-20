using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand
{
    public sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, CreateBrandCommandResponse>
    {
        private readonly IBrandService _service;
        private readonly ILogService _logger;
        private readonly IApiService _apiService;

        public CreateBrandCommandHandler(IBrandService service, ILogService logger, IApiService apiService)
        {
            _service = service;
            _logger = logger;
            _apiService = apiService;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand entity = await _service.CreateBrandAsync(request, cancellationToken);

            string userId = _apiService.GetUserIdByToken();
            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Customer),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(entity)
            };
            await _logger.AddAsync(log, request.companyId);

            return new();
        }
    }
}
