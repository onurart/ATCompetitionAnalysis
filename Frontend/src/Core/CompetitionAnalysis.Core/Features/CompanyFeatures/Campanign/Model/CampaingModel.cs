using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Campanign.Model
{
    public class CampaingModel
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }

        public string? CustomerId { get; set; }
        public string? ProductId { get; set; }
        public string? CategoryId { get; set; }
        public string? BrandId { get; set; }
    }
}
