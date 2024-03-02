using AutoMapper;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Dtos;
using CompetitionAnalysis.Domain.Enums;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductCustomerRelationships;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;
namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class ProductCustomerRelationshipService : IProductCustomerRelationshipService
    {
        private readonly IProductCustomerRelationshipCommandRepository _commandRepository;
        private readonly IProductCustomerRelationshipQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public ProductCustomerRelationshipService(IProductCustomerRelationshipCommandRepository commandRepository, IProductCustomerRelationshipQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<ProductCustomerRelationshipses> CreateProductCustomerRelationshipAsync(CreateProductCustomerRelationshipCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            ProductCustomerRelationshipses relationshipses = _mapper.Map<ProductCustomerRelationshipses>(request);
            relationshipses.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(relationshipses, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return relationshipses;
        }
        public async Task<IList<ProductCustomerRelationshipses>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }
        public async Task<IList<ProductCustomerRelationshipDto>> GetAllDtoAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var result = await _queryRepository.GetAll().Include("Customer").Include("Product").Include("Category").Include("Brand").ToListAsync();
            List<ProductCustomerRelationshipDto> dto = new();
            foreach (var item in result)
            {
                dto.Add(new ProductCustomerRelationshipDto()
                {
                    BrandId = item.Brand?.Id,
                    CategoryId = item.Category?.Id,
                    CustomerId = item.Customer?.Id,
                    ProductId = item.Product?.Id,

                    CategoryName = item.Category?.CategoryName,
                    CustomerName = item.Customer?.Name,
                    BrandName = item.Brand?.BrandName,


                    ProductName = item.Product?.Name,
                    ProductPrice = Convert.ToDecimal(item.Product?.Price),
                    CreatedDate = item.CreatedDate,
                    Explanation = item.Explanation,
                    Specieses = item.Specieses != null ? EnumHelper.GetDisplayName(item.Specieses) : null,
                    RakipTl = item.RakipTl,
                    RakipEuro = item.RakipEuro,
                    RakipDolor = item.RakipDolor,
                    ImageUrl = item.ImageUrl,
                    CurrencyTl = item.CurrencyTl,
                    CurrencyEuro = item.CurrencyEuro,
                    CurrencyDolor = item.CurrencyDolor

                });
            }

            return dto;
        }
        public Task<ProductCustomerRelationshipses> GetByIdAsync(string id, string companyId)
        {
            throw new NotImplementedException();
        }
        public Task<ProductCustomerRelationshipses> RemoveByIdProductCustomerRelationshiptAsync(string id, string companyId)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(ProductCustomerRelationshipses product, string companyId)
        {
            throw new NotImplementedException();
        }
    }
}
