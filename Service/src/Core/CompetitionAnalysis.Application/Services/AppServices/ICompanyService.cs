using CompetitionAnalysis.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CompetitionAnalysis.Domain.AppEntities;

namespace CompetitionAnalysis.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);
        Task UpdateCompany(Company company, CancellationToken cancellationToken);
        //Task UpdatePhotoCompany(string id, string companylogo, CancellationToken cancellationToken);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name, CancellationToken cancellationToken);
        IQueryable<Company> GetAll();
        Task<Company> GetByIdAsync(string id);
    }
}
