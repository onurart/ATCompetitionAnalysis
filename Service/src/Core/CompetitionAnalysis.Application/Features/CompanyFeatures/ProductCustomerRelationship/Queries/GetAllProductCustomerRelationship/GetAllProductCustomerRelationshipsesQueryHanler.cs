using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationship
{
    public sealed class GetAllProductCustomerRelationshipsesQueryHanler : IQueryHandler<GetAllProductCustomerRelationshipQuery, GetAllProductCustomerRelationshipResponse>
    {
        private readonly IProductCustomerRelationshipService _service;

        public GetAllProductCustomerRelationshipsesQueryHanler(IProductCustomerRelationshipService service)
        {
            _service = service;
        }

        public async Task<GetAllProductCustomerRelationshipResponse> Handle(GetAllProductCustomerRelationshipQuery request, CancellationToken cancellationToken)
        {

            return new(await _service.GetAllAsync(request.CompanyId));
        }
    }
}
