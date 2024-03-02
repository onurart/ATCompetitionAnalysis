using CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Services.CompanyService
{
    public interface ICampaignService
    {
        Task<List<GetAllCampaignQuery>> GetAllCampaignAsync(string companyId, string token);
    }
}
