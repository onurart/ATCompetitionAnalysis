using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship
{
    public sealed record
        CreateProductCustomerRelationshipCommand
        (
        string CustomerId,
        string CompanyId,
        string BrandId,
        string CategoryId,
       Specieses Specieses,string Explanation) : ICommand<CreateProductCustomerRelationshipResponse>;

}
