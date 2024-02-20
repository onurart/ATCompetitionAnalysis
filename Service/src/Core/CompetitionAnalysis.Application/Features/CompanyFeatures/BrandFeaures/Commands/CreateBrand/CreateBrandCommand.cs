using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand
{
    public sealed record CreateBrandCommand(string BrandName,string companyId) : ICommand<CreateBrandCommandResponse>;
   
}
