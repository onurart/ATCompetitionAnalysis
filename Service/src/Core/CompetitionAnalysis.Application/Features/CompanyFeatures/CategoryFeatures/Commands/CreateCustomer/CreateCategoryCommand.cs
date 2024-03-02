﻿using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer;
public sealed record CreateCategoryCommand(string CategoryName, string companyId): ICommand<CreateCategoryCommandResponse>;