using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using CompetitionAnalysis.Application.Messaging;
using CompetitionAnalysis.Application.Services.CompanyServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
