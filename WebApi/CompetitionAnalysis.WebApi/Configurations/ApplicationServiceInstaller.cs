using CompetitionAnalysis.Application;
using CompetitionAnalysis.Application.Behavior;
using FluentValidation;
using MediatR;
namespace CompetitionAnalysis.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly); });
            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
        }
    }
}
