using ATCompetitionAnalysis.Presentation.Abstraction;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerCompany;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveByIdCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomerIsActive;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ATCompetitionAnalysis.Presentation.Controller;
public class CustomerController : ApiController
{
    public CustomerController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCustomer(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetAllCustomer(string companyid)
    {
        GetAllCustomerQuery request = new(companyid);
        GetAllCustomerQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    //[AllowAnonymous]
    //[HttpGet("[action]")]
    //public async Task<IActionResult> CreateCustomerAll(CancellationToken cancellationToken)
    //{
    //    CreateCustomerAllCommand request = new();
    //    CreateCustomerAllCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
    //[HttpGet("[action]/{companyid}")]
    //public async Task<IActionResult> CreateCustomerCompany(string companyid, CancellationToken cancellationToken)
    //{
    //    CreateCustomerCompanyCommand request = new(companyid);
    //    CreateCustomerCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
    //[HttpPost("[action]")]
    //public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand request, CancellationToken cancellationToken)
    //{
    //    UpdateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
    //[HttpPost("[action]")]
    //public async Task<IActionResult> UpdateCustomerIsActive(UpdateCustomerIsActiveCommand request, CancellationToken cancellationToken)
    //{
    //    UpdateCustomerIsActiveCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
    
    //[HttpPost("[action]")]
    //public async Task<IActionResult> RemoveByIdCustomer(RemoveByIdCustomerCommand request, CancellationToken cancellationToken)
    //{
    //    RemoveByIdCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
}