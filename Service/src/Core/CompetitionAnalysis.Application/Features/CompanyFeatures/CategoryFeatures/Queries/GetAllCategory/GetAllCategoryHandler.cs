using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory
{
    public sealed class GetAllCategoryHandler : IQueryHandler<GetAllCategoryQuery, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return new(await _categoryService.GetAllCategoryAsync(request.CompanyId));
        }

    }
}
