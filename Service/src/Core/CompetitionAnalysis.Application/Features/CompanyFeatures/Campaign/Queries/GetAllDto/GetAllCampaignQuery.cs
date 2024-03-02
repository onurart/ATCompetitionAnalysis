using CompetitionAnalysis.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Queries.GetAllDto
{
    public sealed record GetAllCampaignQuery(string CompanyId) : IQuery<GetAllCampaigResponse>
    {
    }
}
