using CompetitionAnalysis.Client.Models;
using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace CompetitionAnalysis.Client.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductCustomerRelationshipGet _productCustomerRelationshipGet;
        public HomeController(ILogger<HomeController> logger, IProductCustomerRelationshipGet productCustomerRelationshipGet = null)
        {
            _logger = logger;
            _productCustomerRelationshipGet = productCustomerRelationshipGet;
        }
        
        public async Task<object> GetAlGetProductCustomerRelationship(DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var prp = await _productCustomerRelationshipGet.GetAlGetProductCustomerRelationshipAsync(companyId);
            return DataSourceLoader.Load(prp, loadOptions);
        }
        public async Task<IActionResult> Index()
        {;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
