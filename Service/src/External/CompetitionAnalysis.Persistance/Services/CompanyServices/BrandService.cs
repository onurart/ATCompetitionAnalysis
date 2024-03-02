using AutoMapper;
using Azure.Core;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.BrandRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class BrandService : IBrandService
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private CompanyDbContext _context;

        public BrandService(IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository, IContextService contextService, IMapper mapper, ICompanyDbUnitOfWork unitOfWork = null)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _contextService = contextService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Brand> CreateBrandAsync(CreateBrandCommand requset, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(requset.companyId);
            _brandCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Brand brand = _mapper.Map<Brand>(requset);
            brand.Id = Guid.NewGuid().ToString();
            await _brandCommandRepository.AddAsync(brand, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return brand;
        }

        public async Task<IList<Brand>> GetAllBrandsAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _brandQueryRepository.SetDbContextInstance(_context);
            return await _brandQueryRepository.GetAll().OrderByDescending(x=>x.BrandName).AsNoTracking().ToListAsync();
        }
    }
}
