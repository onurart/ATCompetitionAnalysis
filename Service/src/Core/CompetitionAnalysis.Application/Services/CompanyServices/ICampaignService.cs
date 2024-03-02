using CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Commands.CreateCampaign;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface ICampaignService
    {
        Task<Campaign> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
        Task<IList<Campaign>> GetAllAsync(string companyId);
        Task UpdateAsync(Campaign product, string companyId);
        Task<IList<CampaignDto>> GetAllDtoAsync(string companyId);
        // Task<Campaign> UpdateCampaignIsActiveAsync(string id, string companyId, bool isActive);
        //Task<Campaign> RemoveByIdCampaignAsync(string id, string companyId);
        //Task<Campaign> GetByCampaignCodeAsync(string companyId, string name, CancellationToken cancellationToken);
        //Task<Campaign> GetByIdAsync(string id, string companyId);
    }
}
