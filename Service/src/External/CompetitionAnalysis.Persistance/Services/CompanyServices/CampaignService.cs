using AutoMapper;
using CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Commands.CreateCampaign;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Dtos;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CampaignRepository;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;
namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class CampaignService : ICampaignService
    {
        private readonly ICampaignCommandRepository _campaignCommandRepository;
        private readonly ICampaignQueryRepository _campaignQueryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;
        public CampaignService(ICampaignCommandRepository campaignCommandRepository, ICampaignQueryRepository campaignQueryRepository, IContextService contextService, IMapper mapper, ICompanyDbUnitOfWork unitOfWork)
        {
            _campaignCommandRepository = campaignCommandRepository;
            _campaignQueryRepository = campaignQueryRepository;
            _contextService = contextService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Campaign> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _campaignCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Campaign campaign = _mapper.Map<Campaign>(request);
            campaign.Id = Guid.NewGuid().ToString();
            await _campaignCommandRepository.AddAsync(campaign, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return campaign;
        }
        public async Task<IList<Campaign>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _campaignQueryRepository.SetDbContextInstance(_context);
            return await _campaignQueryRepository.GetAll().AsNoTracking().ToListAsync();
        }

        public async Task<IList<CampaignDto>> GetAllDtoAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _campaignQueryRepository.SetDbContextInstance(_context);
            var result = await _campaignQueryRepository.GetAll().Include("Customer").Include("Product").Include("Category").Include("Brand").ToListAsync();
            List<CampaignDto> dto = new();
            foreach (var item in result)
            {
                dto.Add(new CampaignDto()
                {
                    BrandId = item.BrandId,
                    CategoryId = item.CategoryId,
                    CustomerId = item.CustomerId,
                    ProductId = item.ProductId,
                   
                    CreatedDate = item.CreatedDate,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    
                    
                    ProductName = item.Product?.Name,
                    CategoryName = item.Category.CategoryName,
                    BrandName = item.Brand.BrandName,
                    CustomerName = item.Customer.Name,
                    


                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,


                });

            }
            return dto;
        }

        public async Task UpdateAsync(Campaign product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _campaignCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _campaignCommandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }
        //public Task<Campaign> GetByCampaignCodeAsync(string companyId, string name, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Campaign> GetByIdAsync(string id, string companyId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Campaign> RemoveByIdCampaignAsync(string id, string companyId)
        //{
        //    throw new NotImplementedException();
        //}


        //public Task<Product> UpdateCampaignIsActiveAsync(string id, string companyId, bool isActive)
        //{
        //    throw new NotImplementedException();
        //}      
    }
}