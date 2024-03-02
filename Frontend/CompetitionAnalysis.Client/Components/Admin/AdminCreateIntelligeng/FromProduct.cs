using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompetitionAnalysis.Client.Components.Admin.AdminCreateIntelligeng
{
    public class FromProduct : ViewComponent
    {
        private readonly IProductService _productService;

        public FromProduct(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User as ClaimsPrincipal;
            var token = user?.Claims?.FirstOrDefault(x => x.Type == "token").Value;
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var result = await _productService.GetAllProductAsync(companyId, token);

            var brandModels = result.SelectMany(item => item.Data)
                                    .Select(item => new ProductModel
                                    {
                                        Id = item.Id,
                                        Name = item.Name

                                    })
                                    .ToList();

            return View(brandModels);
        }
    }
}

