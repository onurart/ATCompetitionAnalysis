using CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Query.GetAllCategory;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Commands;
using CompetitionAnalysis.Core.Features.CompanyFeatures.Customer.Quert;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CustomerService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateCategory(CreateCustomerCommand request, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var apiUrl = $"{baseUrl}/Customer/CreateCustomer";
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response =await httpClient.PostAsync(apiUrl, jsonContent);
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

        public async Task<List<GetAllCustomerQueryResponse>> GetAllCustomerAsync(string companyId)
        {
            var httpCLient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            var apiUrl = $"{baseUrl}/Customer/GetAllCustomer/{companyId}";
            var resultList = new List<GetAllCustomerQueryResponse>();
            var response = await httpCLient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var responseCategories = JsonConvert.DeserializeObject<GetAllCustomerQueryResponse>(jsonContent);
                var result = new GetAllCustomerQueryResponse(responseCategories.Data);
                resultList.Add(result);
            }
            return resultList;
        }
    }
}
