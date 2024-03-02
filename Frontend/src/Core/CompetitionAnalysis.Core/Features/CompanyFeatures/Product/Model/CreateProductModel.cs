using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Product.Model
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]

        public decimal Price { get; set; }
        public string CompanyId { get; set; }
    }
}
