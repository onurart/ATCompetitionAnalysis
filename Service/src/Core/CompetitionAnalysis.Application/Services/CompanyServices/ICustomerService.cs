using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerCompany;
using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Services.CompanyServices
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CreateCustomerCommand request, CancellationToken cancellationToken);
        Task CreateCustomerAllAsync(CreateCustomerAllCommand request, CancellationToken cancellationToken);
        Task CreateCustomerCompanyAsync(CreateCustomerCompanyCommand request, CancellationToken cancellationToken);
        Task<IList<Customer>> GetAllAsync(string companyId);
        Task UpdateAsync(Customer customer, string companyId);
        Task<Customer> RemoveByIdCustomerAsync(string id, string companyId);
        Task<Customer> GetByCustomerCodeAsync(string companyId, string customercode, CancellationToken cancellationToken);
        Task<Customer> GetByIdAsync(string id, string companyId);
    }
}
