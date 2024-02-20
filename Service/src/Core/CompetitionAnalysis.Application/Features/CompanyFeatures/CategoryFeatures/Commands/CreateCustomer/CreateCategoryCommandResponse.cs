using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer
{
    public sealed record CreateCategoryCommandResponse(string Message ="Kategory Eklendi");
}
