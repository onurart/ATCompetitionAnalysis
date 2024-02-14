using CompetitionAnalysis.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface ILogService
    {
        Task AddAsync(Log log, string companyId);
        Task<PaginationResult<LogDto>> GetAllByTableName(GetLogsByTableNameQuery request);
    }
}
