using CompetitionAnalysis.Application.Abstractions;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Infrasturcture.Authentication;
using CompetitionAnalysis.Infrasturcture.Services;

namespace CompetitionAnalysis.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IApiService, ApiService>();
        }
    }
}
