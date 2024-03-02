using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Brand.Commands
{
    public class CreateBrandCommand
    {
        public string BrandName { get; set; }
        public string CompanyId { get; set; }

    }
}
