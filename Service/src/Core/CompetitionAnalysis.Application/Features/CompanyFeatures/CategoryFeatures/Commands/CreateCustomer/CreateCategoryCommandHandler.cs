using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer
{
    public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryService _servie;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        public CreateCategoryCommandHandler(ICategoryService servie, ILogService logService = null, IApiService apiService = null)
        {
            _servie = servie;
            _logService = logService;
            _apiService = apiService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category entity = await _servie.CreateCategoryAsync(request,cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Log log =new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(Customer),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(entity)
            };
            await _logService.AddAsync(log, request.companyId);
            return new();
        }
    }
}
