using CompetitionAnalysis.Application.Services.CompanyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries
{
    public sealed class GetAllProductCustomerRelationshipDtoHandler : IRequestHandler<ProductCustomerRelationshipQuery, ProductCustomerRelationshipQueryResponseDto>
    {
        private readonly IProductCustomerRelationshipService _service;

        public GetAllProductCustomerRelationshipDtoHandler(IProductCustomerRelationshipService service)
        {
            _service = service;
        }

        public async Task<ProductCustomerRelationshipQueryResponseDto> Handle(ProductCustomerRelationshipQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllDtoAsync(request.companyId);
            return new  ProductCustomerRelationshipQueryResponseDto(result);
        }
    }
}
