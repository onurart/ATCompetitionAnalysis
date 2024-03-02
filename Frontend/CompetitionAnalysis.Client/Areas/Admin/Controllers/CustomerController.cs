using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Quert;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [Route("Admin/CustomerGridList")]
        public async Task<object> CustomerGridList(DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            List<GetAllCustomerQueryResponse> categories = await _customerService.GetAllCustomerAsync(companyId);
            var categoriesList = categories.SelectMany(item => item.Data).Select(item => new CustomerModel
            {
                Id = item.Id,
                Name = item.Name,
            });
            return DataSourceLoader.Load(categoriesList, loadOptions);
        }
        [Route("Admin/CreateCustomer")]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [Route("Admin/CreateCustomer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand requst)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            requst.CompanyId = companyId;
            var result = _customerService.CreateCategory(requst, token);
            return RedirectToAction("Customer","Admin");
        }

    }
}
