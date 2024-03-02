using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Commands;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Query;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using Newtonsoft.Json.Linq;

namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public BrandRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<GetAllBrandQueryResponse>> GetAllBrand(string companyId , string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiUrl = $"{baseUrl}/Brand/GetAllBrand/{companyId}";
            var resultList = new List<GetAllBrandQueryResponse>();
            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var responseCategories = JsonConvert.DeserializeObject<GetAllBrandQueryResponse>(jsonContent);
                var result = new GetAllBrandQueryResponse(responseCategories.Data);
                resultList.Add(result);
            }
            return resultList;

        }

        public async Task<bool> CreateBrand(CreateBrandCommand request, string token)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var apiSettings = _configuration.GetSection("ApiSettings");
                var baseUrl = apiSettings["BaseUrl"];
                var apiUrl = $"{baseUrl}/Brand/CreateBrand";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        //public async Task<List<GetAllBrandQueryResponse>> GetAllBrand(string token)
        //{
        //    var httpClient = _httpClientFactory.CreateClient();
        //    var apiSettings = _configuration.GetSection("ApiSettings");
        //    var baseUrl = apiSettings["BaseUrl"]; // BaseUrl'i alın
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //    var apiUrl = $"{baseUrl}/Brand/GetAllCustomer";
        //    var resultList = new List<GetAllBrandQueryResponse>();
        //    var response = await httpClient.GetAsync(apiUrl);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonContent = await response.Content.ReadAsStringAsync();
        //        var responseUser = JsonConvert.DeserializeObject<GetAllBrand>(jsonContent);
        //        var result = new GetAllBrandQueryResponse();
        //        resultList.Add(result);
        //    }
        //    return resultList;
        //}
    }
}
