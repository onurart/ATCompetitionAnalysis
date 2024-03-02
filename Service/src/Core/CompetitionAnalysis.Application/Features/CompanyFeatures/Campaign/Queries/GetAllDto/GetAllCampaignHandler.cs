using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Queries.GetAllDto
{
    public sealed class GetAllCampaignHandler : IQueryHandler<GetAllCampaignQuery, GetAllCampaigResponse>
    {
        private readonly ICampaignService _campaignService;

        public GetAllCampaignHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<GetAllCampaigResponse> Handle(GetAllCampaignQuery request, CancellationToken cancellationToken)
        {
            var result = await _campaignService.GetAllDtoAsync(request.CompanyId);
            return new GetAllCampaigResponse(result);
        }
    }
}
