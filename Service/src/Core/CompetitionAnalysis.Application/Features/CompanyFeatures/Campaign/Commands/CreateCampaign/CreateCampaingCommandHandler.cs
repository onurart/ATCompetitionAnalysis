using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;
using System.Globalization;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Commands.CreateCampaign
{
    public sealed class CreateCampaingCommandHandler : ICommandHandler<CreateCampaignCommand, CreateCampaignCommandResponse>
    {
        private readonly ICampaignService _campaignService;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        public CreateCampaingCommandHandler(ICampaignService campaignService, ILogService logService, IApiService apiService)
        {
            _campaignService = campaignService;
            _logService = logService;
            _apiService = apiService;
        }

        public async Task<CreateCampaignCommandResponse> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            CompetitionAnalysis.Domain.CompanyEntities.Campaign entity = await _campaignService.CreateCampaignAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(CompetitionAnalysis.Domain.CompanyEntities.Campaign),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(entity)
            };
            await _logService.AddAsync(log, request.CategoryId);
            return new();
        }

    }
}
