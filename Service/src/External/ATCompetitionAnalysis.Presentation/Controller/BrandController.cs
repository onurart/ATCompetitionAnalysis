using ATCompetitionAnalysis.Presentation.Abstraction;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATCompetitionAnalysis.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class BrandController : ApiController
    {
        public BrandController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand requst,CancellationToken cancellationToken)
        {
            CreateBrandCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllBrand(string companyid)
        {
            GetAllBrandQuery requst = new(companyid);
            GetAllBrandQueryResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
    }
}
