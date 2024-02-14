using CompetitionAnalysis.Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitionAnalysis.Persistance.Constans;

namespace CompetitionAnalysis.Persistance.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.Products);
            builder.HasKey(p => p.Id);
        }
    }
}
