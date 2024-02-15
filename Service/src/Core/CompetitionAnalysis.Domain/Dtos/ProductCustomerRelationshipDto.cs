using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Domain.Dtos
{
    public sealed class ProductCustomerRelationshipDto
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public decimal? Price { get; set; }
        public decimal ProductPrice { get; set; }


        //public string ProductId { get; set; }
        //public string ProductName { get; set; }
        //public string CustomerId { get; set; }
        //public string CustomerName { get; set; }
        //public decimal Price { get; set; }
        //
        //public decimal AsinPrice { get; set; }
    }
}
