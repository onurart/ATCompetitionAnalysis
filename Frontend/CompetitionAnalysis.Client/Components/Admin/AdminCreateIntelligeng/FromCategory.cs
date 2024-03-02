using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompetitionAnalysis.Client.Components.Admin.AdminCreateIntelligeng
{
    public class FromCategory:ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public FromCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User as ClaimsPrincipal;
            var token = user?.Claims?.FirstOrDefault(x => x.Type == "token").Value;
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var result = await _categoryService.GetAllCategoriesAsync(companyId, token);

            var categoryModels = result.SelectMany(item => item.Data)
                                    .Select(item => new CategoryModel
                                    {
                                        Id = item.Id,
                                        CategoryName = item.CategoryName
                                    })
                                    .ToList();

            return View(categoryModels);
        }
    }
}
