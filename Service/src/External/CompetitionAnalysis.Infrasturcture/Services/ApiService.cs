using CompetitionAnalysis.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Infrasturcture.Services
{
    public sealed class ApiService : IApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserIdByToken()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Contains("authentication"))?.Value;
            return userId ?? string.Empty;
        }
    }
}
