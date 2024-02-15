using CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship;
using CompetitionAnalysis.Core.Services.CompanyService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
namespace CompetitionAnalysis.Core.Repositories.CompanyRepositories
{
    public class ProductCustomerRelationship : IProductCustomerRelationshipGet
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public ProductCustomerRelationship(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<List<GetProductCustomerRelationship>> GetAlGetProductCustomerRelationshipAsync(string companyId)
        {

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var apiSettings = _configuration.GetSection("ApiSettings");
                var baseUrl = apiSettings["BaseUrl"];
                var apiUrl = $"{baseUrl}/Product/GetProductCustomerRelationshipDto/{companyId}";
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<ApiResponse<List<GetProductCustomerRelationship>>>(jsonContent);
                    if (jsonResponse != null && jsonResponse.Data != null)
                    {
                        var result = jsonResponse.Data;
                        return result;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return null;
            }
        }
        public class ApiResponse<T>
        {
            public T Data { get; set; }
        }
    }
}
