using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship.Commands;
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

namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class IntelligengeService : IIntelligengeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public IntelligengeService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<bool> CreateIntelligenge(CreateProductCustomerRelationshipCommand request, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiSettegins = _configuration.GetSection("ApiSettings");
            var baseUrl = apiSettegins["BaseUrl"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var apiUrl = $"{baseUrl}/Product/CreateProductCustomerRelationship";
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
    }
}
