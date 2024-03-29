﻿using System.ComponentModel.DataAnnotations;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.GetAllProductCustomerRelationship
{
    public class GetProductCustomerRelationship
    {
        public string? CustomerName { get; set; }
        public string Specieses { get; set; }
        public string? ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public string? Explanation { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? CurrencyTl { get; set; }
        public decimal? CurrencyDolor { get; set; }
        public decimal? CurrencyEuro { get; set; }
        public decimal? RakipTl { get; set; }
        public decimal? RakipDolor { get; set; }
        public decimal? RakipEuro { get; set; }
    
    }
}
