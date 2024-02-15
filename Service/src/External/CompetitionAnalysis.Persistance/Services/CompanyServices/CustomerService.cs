using AutoMapper;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;
namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICompanyQueryRepository _companyQueryRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private CompanyDbContext _context;

        public CustomerService(ICustomerCommandRepository commandRepository, ICustomerQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper, ICompanyQueryRepository companyQueryRepository, IHttpClientFactory httpClientFactory, IProductQueryRepository productQueryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _companyQueryRepository = companyQueryRepository;
            _httpClientFactory = httpClientFactory;
            _productQueryRepository = productQueryRepository;
        }
        public async Task<Customer> CreateCustomerAsync(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Customer entity = _mapper.Map<Customer>(request);
            entity.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public async Task<IList<Customer>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().OrderBy(p => p.Name).ToListAsync();
        }
        public async Task<Customer> GetByCustomerCodeAsync(string companyId, string name, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetFirstByExpiression(p => p.Name == name, cancellationToken);
        }
        public async Task<Customer> GetByIdAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetById(id);
        }
        public async Task<Customer> RemoveByIdCustomerAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            Customer entity = await _queryRepository.GetById(id);
            _commandRepository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Customer customer, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(customer);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
