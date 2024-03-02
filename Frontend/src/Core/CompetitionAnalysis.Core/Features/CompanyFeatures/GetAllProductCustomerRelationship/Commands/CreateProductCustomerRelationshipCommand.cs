using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship.Commands
{
    public class CreateProductCustomerRelationshipCommand
    {


        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
        public string Explanation { get; set; }
        public string ImageUrl { get; set; }
        public decimal CurrencyDolor { get; set; }
        public decimal CurrencyEuro { get; set; }
        public decimal CurrencyTl { get; set; }
        public decimal RakipDolor { get; set; }
        public decimal RakipEuro { get; set; }
        public decimal RakipTl { get; set; }
        public int Specieses { get; set; }

    }
}
