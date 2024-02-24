using AutoMapper;
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
        private readonly IBrandQueryRepository  _brandQueryRepository;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
        private CompanyDbContext _context;
        public BrandService(IBrandCommandRepository baranCommandRepository, IBrandQueryRepository brandQueryRepository, IContextService contextService, IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork)
        {
            _brandCommandRepository = baranCommandRepository;
            _brandQueryRepository = brandQueryRepository;
            _contextService = contextService;
            _mapper = mapper;
            _companyDbUnitOfWork = companyDbUnitOfWork;
        }
        public async Task<Brand> CreateBrandAsync(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _brandCommandRepository.SetDbContextInstance(_context);
            _companyDbUnitOfWork.SetDbContextInstance(_context);
            Brand entity = _mapper.Map<Brand>(request);
            entity.Id = Guid.NewGuid().ToString();
            await _brandCommandRepository.AddAsync(entity, cancellationToken);
            await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IList<Brand>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _brandQueryRepository.SetDbContextInstance(_context);
            return await _brandQueryRepository.GetAll().OrderBy(x=>x.BrandName).ToListAsync();
        }
    }
}
