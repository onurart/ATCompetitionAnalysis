using CompetitionAnalysis.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationshipQueryDto
{
    public sealed record ProductCustomerRelationshipQuery(string companyId) : IQuery<ProductCustomerRelationshipQueryResponseDto>;

}
