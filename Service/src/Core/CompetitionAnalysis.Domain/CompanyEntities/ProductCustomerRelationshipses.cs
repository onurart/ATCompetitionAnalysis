using CompetitionAnalysis.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.CompanyEntities
{
    public sealed class ProductCustomerRelationshipses:Entity
    {
        public decimal Price { get; set; }
        [ForeignKey(nameof(ProductId))]
        public string? ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public string? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
