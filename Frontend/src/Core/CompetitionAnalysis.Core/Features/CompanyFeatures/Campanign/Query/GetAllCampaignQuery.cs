using CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Query
{
    public sealed record GetAllCampaignQuery(List<CampaingModel> Data);
    
}
