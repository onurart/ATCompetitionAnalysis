using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Model;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompetitionAnalysis.Client.Components.Admin.AdminCreateIntelligeng
{
    public class FromCustomer :ViewComponent
    {
        private readonly ICustomerService _customerService;

        public FromCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User as ClaimsPrincipal;
            var token = user?.Claims?.FirstOrDefault(x => x.Type == "token").Value;
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var result = await _customerService.GetAllCustomerAsync(companyId);

            var customerModels = result.SelectMany(item => item.Data)
                                       .Select(item => new CustomerModel
                                       {
                                           Id = item.Id,
                                           Name = item.Name
                                       })
                                       .ToList();

            return View(customerModels);
        }
    }
}
