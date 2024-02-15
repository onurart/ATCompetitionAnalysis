using CompetitionAnalysis.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries
{
    public sealed record ProductCustomerRelationshipQueryResponseDto(IList<ProductCustomerRelationshipDto> Data);
   
}
