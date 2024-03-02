using CompetitionAnalysis.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
namespace CompetitionAnalysis.Domain.CompanyEntities
{
    public sealed class Campaign : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(BrandId))]
        public string? BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public string? CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(ProductId))]
        public string? ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public string? CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public decimal CurrencyTl { get; set; }
        //public decimal CurrencyDolor { get; set; }
        //public decimal CurrencyEuro { get; set; }
    }
}
