﻿using CompetitionAnalysis.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationship
{
    public sealed record GetAllProductCustomerRelationshipQuery(string CompanyId): IQuery<GetAllProductCustomerRelationshipResponse>
    {
    }
}
