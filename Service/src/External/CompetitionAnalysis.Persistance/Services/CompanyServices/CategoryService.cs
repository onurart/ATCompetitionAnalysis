using AutoMapper;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CategoryRepository;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CategoryRepository;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IContextService _contextService;
        private readonly IMapper _mapper;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private CompanyDbContext _context;

        public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, IContextService contextService, IMapper mapper, ICompanyDbUnitOfWork unitOfWork)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _contextService = contextService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _categoryCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Category entity = _mapper.Map<Category>(request);
            entity.Id = Guid.NewGuid().ToString();
            await _categoryCommandRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<IList<Category>> GetAllCategoryAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _categoryQueryRepository.SetDbContextInstance(_context);
            return await _categoryQueryRepository.GetAll().OrderBy(p => p.CategoryName).ToListAsync();
        }
    }
}
