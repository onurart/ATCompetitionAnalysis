using CompetitionAnalysis.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer
{
    public sealed record CreateCategoryCommand(string CategoryName, string companyId): ICommand<CreateCategoryCommandResponse>; 

}
