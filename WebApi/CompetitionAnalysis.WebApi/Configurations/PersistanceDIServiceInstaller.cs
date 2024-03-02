using CompetitionAnalysis.Application.Services.AppServices;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.MainRoleReporistories;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.UserRoleRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.BrandRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CampaignRepository;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CategoryRepository;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.LogRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductCustomerRelationships;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Persistance;
using CompetitionAnalysis.Persistance.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Persistance.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
using CompetitionAnalysis.Persistance.Repositories.AppDbContext.MainRoleRepositories;
using CompetitionAnalysis.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository;
using CompetitionAnalysis.Persistance.Repositories.AppDbContext.UserRoleRepositories;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.BrandRepositories;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CampaignRepository;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CategoryRepository;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.CustomerRepositories;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.LogRepositories;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.ProductCustomerRelationships;
using CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Persistance.Services.AppServices;
using CompetitionAnalysis.Persistance.Services.CompanyServices;
using CompetitionAnalysis.Persistance.UnitOfWorks;
namespace CompetitionAnalysis.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion

            #region Services
            #region CompanyDbContext
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductCustomerRelationshipService, ProductCustomerRelationshipService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICampaignService, CampaignService>();
            #endregion

            #region AppDbContext
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();
            services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            #endregion
            #endregion

            #region Repositories
            #region CompanyDbContext
            services.AddScoped<ILogCommandRepository, LogCommandRepository>();
            services.AddScoped<ILogQueryRepository, LogQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<IProductCustomerRelationshipCommandRepository, ProductCustomerRelationshipsCommandRepository>();
            services.AddScoped<IProductCustomerRelationshipQueryRepository, ProductCustomerRelationshipsQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

            services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
            services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();

            services.AddScoped<ICampaignCommandRepository, CampaignCommandRepository>();
            services.AddScoped<ICampaignQueryRepository, CampaignQueryRepository>();


            services.AddHttpClient();

            #endregion


            #region AppDbContext
            services.AddScoped<ICompanyCommandRepository, CompanyCommandRepository>();
            services.AddScoped<ICompanyQueryRepository, CompanyQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipCommandRepository, MainRoleAndUserRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipQueryRepository, MainRoleAndUserRelationshipQueryRepository>();
            services.AddScoped<IUserAndCompanyRelationshipCommandRepository, UserAndCompanyRelationshipCommandRepository>();
            services.AddScoped<IUserAndCompanyRelationshipQueryRepository, UserAndCompanyRelationshipQueryRepository>();
            services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
            services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
            #endregion
            #endregion
        }
    }
}
