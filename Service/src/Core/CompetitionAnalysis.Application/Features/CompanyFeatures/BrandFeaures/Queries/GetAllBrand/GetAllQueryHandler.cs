using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand
{
    public class GetAllQueryHandler : IQueryHandler<GetAllBrandQuery, GetAllBrandQueryResponse>
    {
        private readonly IBrandService _brandService;

        public GetAllQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<GetAllBrandQueryResponse> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return new(await _brandService.GetAllAsync(request.CompanyId));
        }
    }
    }
