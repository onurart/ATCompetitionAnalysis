using ATCompetitionAnalysis.Presentation.Abstraction;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCompetitionAnalysis.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class CategoryController : ApiController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }
       
        [HttpPost("[action]")]        
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllCategory(string companyid)
        {
            GetAllCategoryQuery request = new(companyid);
            GetAllCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
