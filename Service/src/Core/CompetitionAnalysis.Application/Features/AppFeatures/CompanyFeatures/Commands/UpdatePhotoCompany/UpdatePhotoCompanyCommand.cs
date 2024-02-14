using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.AppFeatures.CompanyFeatures.Commands.UpdatePhotoCompany;
public sealed record UpdatePhotoCompanyCommand(string id, string companylogo) : ICommand<UpdatePhotoCompanyCommandResponse>;
