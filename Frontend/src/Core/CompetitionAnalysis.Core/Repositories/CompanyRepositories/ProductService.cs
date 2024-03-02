using CompetitionAnalysis.Core.Features.CompanyFeatures.Product;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateProduct(CreateProductModel request, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var apiUrl = $"{baseUrl}/Product/CreateProduct/";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return false;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API call failed. Status code: {response.StatusCode}. Error: {errorMessage}");
            }
        }

        public async Task<List<GetAllProductQueryResponse>> GetAllProductAsync(string companyId, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiUrl = $"{baseUrl}/Product/GetAllProduct/{companyId}";
            var resultList = new List<GetAllProductQueryResponse>();
            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var responseCategories = JsonConvert.DeserializeObject<GetAllProductQueryResponse>(jsonContent);
                var result = new GetAllProductQueryResponse(responseCategories.Data);
                resultList.Add(result);
            }
            return resultList;
        }
    }
}

