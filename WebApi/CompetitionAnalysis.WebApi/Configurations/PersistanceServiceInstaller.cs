using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Persistance;
using CompetitionAnalysis.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(SectionName);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        }
    }

}
