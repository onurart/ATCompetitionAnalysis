using CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Query;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class CampaignService : ICampaignService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CampaignService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<List<GetAllCampaignQuery>> GetAllCampaignAsync(string companyId, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiUrl = $"{baseUrl}/Campaign/GetAllCampaignDto/{companyId}";
            var resultList = new List<GetAllCampaignQuery>();
            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var responseCategories = JsonConvert.DeserializeObject<GetAllCampaignQuery>(jsonContent);
                var result = new GetAllCampaignQuery(responseCategories.Data);
                resultList.Add(result);
            }
            return resultList;
        }
    }
}
