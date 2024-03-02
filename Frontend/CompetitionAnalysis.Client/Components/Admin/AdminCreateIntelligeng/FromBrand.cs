using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompetitionAnalysis.Client.Components.Admin.AdminCreateIntelligeng
{
    public class FromBrand : ViewComponent
    {
        private readonly IBrandRepository _brandRepository;

        public FromBrand(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

            public async Task<IViewComponentResult> InvokeAsync()
            {
            var user = User as ClaimsPrincipal;
            var token = user?.Claims?.FirstOrDefault(x => x.Type == "token").Value;
            string companyId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "CompanyId")?.Value;
            var result = await _brandRepository.GetAllBrand(companyId, token);

            var brandModels = result.SelectMany(item => item.Data)
                                    .Select(item => new GetAllBrand
                                    {   
                                        Id = item.Id,
                                        BrandName = item.BrandName
                                    })
                                    .ToList();

            return View(brandModels);
        }
    }
}
