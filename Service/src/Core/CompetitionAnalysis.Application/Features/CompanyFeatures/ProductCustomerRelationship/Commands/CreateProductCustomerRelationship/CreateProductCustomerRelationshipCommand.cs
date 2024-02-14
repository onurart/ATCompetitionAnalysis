﻿using CompetitionAnalysis.Application.Messaging;
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
        (string ProductId,string CustomerId,decimal Price,string ComapanyId) : ICommand<CreateProductCustomerRelationshipResponse>;
}