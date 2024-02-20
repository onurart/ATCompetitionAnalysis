using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public string BrandName { get; set; }
        public string BrandId{ get; set; }
        [Display(Name =  "Specieses")]
        public string Specieses { get; set; }
        public string? Explanation { get; set; }
        //public string ProductId { get; set; }
        //public string ProductName { get; set; }
        //public string CustomerId { get; set; }
        //public string CustomerName { get; set; }
        //public decimal Price { get; set; }
        //
        //public decimal AsinPrice { get; set; }
    }
}
