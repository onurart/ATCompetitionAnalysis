using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CategoryService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateCaegory(CreateCategory request,string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var apiUrl = $"{baseUrl}/Category/CreateCategory";
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

        public async Task<List<GetAllCategory>> GetAllCategoriesAsync(string companyId, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiUrl = $"{baseUrl}/Category/GetAllCategory/{companyId}";
            var resultList = new List<GetAllCategory>();
            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var responseCategories = JsonConvert.DeserializeObject<GetAllCategory>(jsonContent);
                var result = new GetAllCategory(responseCategories.Data);
                resultList.Add(result);
            }
            return resultList;

        }
    }
}
