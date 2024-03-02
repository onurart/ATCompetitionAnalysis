using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Constans
{
    public static class TableNames
    {
        public static string Customers = nameof(Customers);
        public static string Products = nameof(Products);
        public static string ProductCustomerRelationship = nameof(ProductCustomerRelationship);
        public static string Logs = nameof(Logs);
        public static string Brand = nameof(Brand);
        public static string Category = nameof(Category);
        public static string Campaign = nameof(Campaign);
        public static string SliderBanner = nameof(SliderBanner);
    }
}
