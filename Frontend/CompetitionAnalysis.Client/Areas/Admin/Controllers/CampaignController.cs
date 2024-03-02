using CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Query;
using CompetitionAnalysis.Core.Services.CompanyService;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/CampanigGridList")]

        public async Task<object> CampanigGridList(DataSourceLoadOptions loadOptions)
        {
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var token = User.Claims.FirstOrDefault(x => x.Type == "token")?.Value;
            List<GetAllCampaignQuery> campaing = await _campaignService.GetAllCampaignAsync(companyId, token);
            var campaingList = campaing.SelectMany(item => item.Data).Select(item => new CampaingModel
            {
                BrandId = item.BrandId,
                BrandName = item.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.CategoryName,
                CreatedDate = DateTime.Now,
                CustomerId = item.CustomerId,
                CustomerName = item.CustomerName,
                EndDate = DateTime.Now,
                ImageUrl = item.ImageUrl,
                Name = item.Name,
                Price = item.Price,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                StartDate = item.StartDate
            });
            return DataSourceLoader.Load(campaingList, loadOptions);
        }

    }
}
