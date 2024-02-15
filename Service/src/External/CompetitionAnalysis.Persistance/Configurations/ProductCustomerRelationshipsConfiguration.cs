using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Persistance.Constans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Configurations
{
    public sealed class ProductCustomerRelationshipsConfiguration : IEntityTypeConfiguration<ProductCustomerRelationshipses>
    {
        public void Configure(EntityTypeBuilder<ProductCustomerRelationshipses> builder)
        {
            builder.ToTable(TableNames.ProductCustomerRelationship);
            builder.HasKey(p => p.Id);
        }
    }
}
