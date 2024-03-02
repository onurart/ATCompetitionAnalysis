using CompetitionAnalysis.Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Persistance.Configurations
{
    public sealed class SliderBannerConfiguration : IEntityTypeConfiguration<SliderBanner>
    {
        public void Configure(EntityTypeBuilder<SliderBanner> builder)
        {
            builder.ToTable(nameof(SliderBanner));
            builder.HasKey(x => x.Id);
        }
    }
}
