using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/CategoriesList")]
        public async Task<object> CategoriesList (DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;

            List<GetAllCategory> categories = await _categoryService.GetAllCategoriesAsync(companyId,token);
            var categoriesList = categories.SelectMany(item => item.Data).Select(item => new CategoryModel
            {
                Id = item.Id,
                CategoryName=item.CategoryName,
                CreatedDate = DateTime.Now,
                IsActive = true,

                
            });
            return DataSourceLoader.Load(categoriesList, loadOptions);

        }
        [Route("Admin/CreateCategory")]
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [Route("Admin/CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategory requst)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            requst.CompanyId = companyId;
            var result = await _categoryService.CreateCaegory(requst, token);
            return RedirectToAction("Categories", "Admin"); 
        }
        //[Route("Admin/InsertCagegory")]
        //[HttpPost]
        //public async Task<object> InsertCagegory(CreateCategory requst, DataSourceLoadOptions loadOptions)
        //{
        //    string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
        //    var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
        //    var result = await _categoryService.CreateCaegory(requst,companyId,token);
        //    return result;
        //}

    }
}
