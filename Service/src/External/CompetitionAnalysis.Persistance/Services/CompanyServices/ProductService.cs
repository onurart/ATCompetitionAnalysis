using AutoMapper;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private CompanyDbContext _context;
        public ProductService(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Product> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Product product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product;
        }
        public async Task<IList<Product>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }


        public async Task UpdateAsync(Product product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }
































        //public async Task<Product> GetByIdAsync(string id, string companyId)
        //{
        //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        //    _queryRepository.SetDbContextInstance(_context);
        //    return await _queryRepository.GetById(id);
        //}
        //public async Task<Product> GetByProductCodeAsync(string companyId, string productcode, CancellationToken cancellationToken)
        //{
        //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        //    _queryRepository.SetDbContextInstance(_context);
        //    return await _queryRepository.GetFirstByExpiression(p => p.Name == productcode, cancellationToken);
        //}
        //public async Task<Product> RemoveByIdProductAsync(string id, string companyId)
        //{
        //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        //    _commandRepository.SetDbContextInstance(_context);
        //    _unitOfWork.SetDbContextInstance(_context);
        //    _queryRepository.SetDbContextInstance(_context);
        //    Product product = await _queryRepository.GetById(id);
        //    _commandRepository.Remove(product);
        //    await _unitOfWork.SaveChangesAsync();
        //    return product;
        //}

        //public async Task<Product> UpdateProductIsActiveAsync(string id, string companyId, bool isActive)
        //{
        //    _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        //    _commandRepository.SetDbContextInstance(_context);
        //    _unitOfWork.SetDbContextInstance(_context);
        //    _queryRepository.SetDbContextInstance(_context);
        //    Product product = await _queryRepository.GetById(id);
        //    product.IsActive = isActive;
        //    _commandRepository.Update(product);
        //    await _unitOfWork.SaveChangesAsync();
        //    return product;
        //}
    }
}
