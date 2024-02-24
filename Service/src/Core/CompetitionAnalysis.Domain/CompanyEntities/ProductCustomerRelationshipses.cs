using CompetitionAnalysis.Domain.Abstractions;
using CompetitionAnalysis.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.CompanyEntities
{
    public sealed class ProductCustomerRelationshipses : Entity
    {
        //public decimal Price { get; set; }
        //[ForeignKey(nameof(ProductId))]
        //public string? ProductId { get; set; }
        //public Product Product { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public string? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Specieses Specieses { get; set; }


        [ForeignKey(nameof(BrandId))]
        public string? BrandId { get; set; }
        public Brand Brand { get; set; }




        [ForeignKey(nameof(CategoryId))]
        public string? CategoryId { get; set; }
        public Category Category { get; set; }




        public string? Explanation { get; set; }
    }
}
