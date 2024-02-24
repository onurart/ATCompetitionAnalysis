using ATCompetitionAnalysis.Presentation.Abstraction;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCompetitionAnalysis.Presentation.Controller
{
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
            GetAllBrandQuery request = new(companyid);
            GetAllBrandQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
