﻿using CompetitionAnalysis.Domain.CompanyEntities;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
public sealed record GetAllCustomerQueryResponse(IList<Customer> Data);