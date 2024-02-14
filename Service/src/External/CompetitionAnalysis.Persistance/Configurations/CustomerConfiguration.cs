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
    public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(TableNames.Customers);
            builder.HasKey(p => p.Id);
        }
    }
}
