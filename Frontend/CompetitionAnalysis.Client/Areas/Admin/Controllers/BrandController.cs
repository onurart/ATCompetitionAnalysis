using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        [Route("Admin/BrandList")]
        public async Task<object> BrandList(DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;

            List<GetAllBrandQueryResponse> categories = await _brandRepository.GetAllBrand(companyId, token);
            var categoriesList = categories.SelectMany(item => item.Data).Select(item => new GetAllBrand
            {
                Id = item.Id,
                BrandName = item.BrandName,



            });
            return DataSourceLoader.Load(categoriesList, loadOptions);

        }
        [Route("Admin/CreateBrand")]
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }
        [Route("Admin/CreateBrand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand requst)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            requst.CompanyId = companyId;
            var result = await _brandRepository.CreateBrand(requst,token);
            return RedirectToAction("brand", "Admin");
        }
    }
}
