using CompetitionAnalysis.Core.Features.CompanyFeatures.Product;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/GetProductGrid")]
        public async Task<object> GetProductGrid(DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            List<GetAllProductQueryResponse> categories = await _productService.GetAllProductAsync(companyId,token);
            var productList = categories.SelectMany(item => item.Data).Select(item => new ProductModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,


            });
            return DataSourceLoader.Load(productList, loadOptions);
        }


        [Route("Admin/ProductCreate")]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [Route("Admin/ProductCreate")]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(CreateProductModel request)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            request.CompanyId = companyId;

            var result = await _productService.CreateProduct(request, token);
            return RedirectToAction("Product", "Admin");
        }
    }
}
