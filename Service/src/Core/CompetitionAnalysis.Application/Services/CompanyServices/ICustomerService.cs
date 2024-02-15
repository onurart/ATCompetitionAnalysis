using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Domain.CompanyEntities;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CreateCustomerCommand request, CancellationToken cancellationToken);
        Task<IList<Customer>> GetAllAsync(string companyId);
        Task UpdateAsync(Customer customer, string companyId);
        Task<Customer> RemoveByIdCustomerAsync(string id, string companyId);
        Task<Customer> GetByCustomerCodeAsync(string companyId, string customercode, CancellationToken cancellationToken);
        Task<Customer> GetByIdAsync(string id, string companyId);
    }
}
