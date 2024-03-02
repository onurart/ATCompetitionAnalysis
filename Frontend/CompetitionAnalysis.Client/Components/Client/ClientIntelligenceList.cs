using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompetitionAnalysis.Client.Components.Client
{
    public class ClientIntelligenceList:ViewComponent
    {
        private readonly IProductCustomerRelationshipGet _productCustomerRelationshipGet;

        public ClientIntelligenceList(IProductCustomerRelationshipGet productCustomerRelationshipGet = null)
        {
            _productCustomerRelationshipGet = productCustomerRelationshipGet;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var user = User as ClaimsPrincipal;
            var token = user?.Claims?.FirstOrDefault(x => x.Type == "token")?.Value;

            if (companyId == null || token == null)
            {
                // Hata durumunu işle
                return View("Error"); // Veya başka bir şey yapabilirsiniz
            }

            var prp = await _productCustomerRelationshipGet.GetAlGetProductCustomerRelationshipAsync(companyId, token);

            if (prp == null)
            {
                // prp null ise boş bir liste oluştur
                prp = new List<GetProductCustomerRelationship>(); // Eğer prp'nin türü GetProductCustomerRelationship ise burayı ona göre değiştirin
            }

            var liste = prp.Select(item =>
            {
                return new GetProductCustomerRelationship
                {
                    BrandId = item.BrandId,
                    BrandName = item.BrandName,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                    CreatedDate = item.CreatedDate,
                    CustomerId = item.CustomerId,
                    CustomerName = item.CustomerName,
                    Explanation = item.Explanation,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.ProductPrice,
                    Specieses = item.Specieses,
                    ImageUrl=item.ImageUrl,
                    CurrencyDolor = item.CurrencyDolor.HasValue ? Decimal.Parse(item.CurrencyDolor.Value.ToString("N0")) : (decimal?)null,
                    CurrencyEuro = item.CurrencyEuro.HasValue ? Decimal.Parse(item.CurrencyEuro.Value.ToString("N1")) : (decimal?)null,
                    CurrencyTl = item.CurrencyTl.HasValue ? Decimal.Parse(item.CurrencyTl.Value.ToString("N0")) : (decimal?)null,

                    // Diğer özellikler...

                    RakipDolor = item.RakipDolor.HasValue ? Decimal.Parse(item.RakipDolor.Value.ToString("N0")) : (decimal?)null,
                    RakipEuro = item.RakipEuro.HasValue ? Decimal.Parse(item.RakipEuro.Value.ToString("N0")) : (decimal?)null,
                    RakipTl = item.RakipTl.HasValue ? Decimal.Parse(item.RakipTl.Value.ToString("N0")) : (decimal?)null
                };
            }).ToList();


            return View(liste);




        }
    }
}
