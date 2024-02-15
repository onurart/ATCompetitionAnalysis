using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using Newtonsoft.Json;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship
{
    public sealed class CreateProductCustomerRelationshipHadler : ICommandHandler<CreateProductCustomerRelationshipCommand, CreateProductCustomerRelationshipResponse>
    {
        private readonly IProductCustomerRelationshipService _productCustomerRelationship;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;

        public CreateProductCustomerRelationshipHadler(IProductCustomerRelationshipService productCustomerRelationship, IApiService apiService = null, ILogService logService = null)
        {
            _productCustomerRelationship = productCustomerRelationship;
            _apiService = apiService;
            _logService = logService;
        }

        public async Task<CreateProductCustomerRelationshipResponse> Handle(CreateProductCustomerRelationshipCommand request, CancellationToken cancellationToken)
        {
            ProductCustomerRelationshipses relationshipses = await _productCustomerRelationship.CreateProductCustomerRelationshipAsync(request, cancellationToken);
            string userId = _apiService.GetUserIdByToken();
            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(ProductCustomerRelationshipses),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(relationshipses)
            };
            await _logService.AddAsync(log, request.CompanyId);

            return new();
        }
    }
}
