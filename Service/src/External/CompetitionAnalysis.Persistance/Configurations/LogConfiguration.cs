using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Persistance.Constans;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Configurations
{
    public sealed class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(TableNames.Logs);
            builder.HasKey(t => t.Id);
        }

    }
    }
