using ATCompetitionAnalysis.Presentation.Abstraction;
using CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Commands.CreateCampaign;
using CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Queries.GetAllDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace ATCompetitionAnalysis.Presentation.Controller
{
    public class CampaignController : ApiController
    {
        public CampaignController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignCommand requst, CancellationToken cancellationToken)
        {
            CreateCampaignCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllCampaignDto(string companyid)
        {
            GetAllCampaignQuery requst = new(companyid);
            GetAllCampaigResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
    }
}
