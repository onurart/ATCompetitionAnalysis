using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerCompany;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.CustomerRepositories;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductRepositories;
using CompetitionAnalysis.Domain.UnitOfWorks;
using CompetitionAnalysis.Domain;
using CompetitionAnalysis.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICompanyQueryRepository _companyQueryRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private CompanyDbContext _context;

        public CustomerService(ICustomerCommandRepository commandRepository, ICustomerQueryRepository queryRepository,
            IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper,
            ICompanyQueryRepository companyQueryRepository, IHttpClientFactory httpClientFactory, IProductQueryRepository productQueryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _companyQueryRepository = companyQueryRepository;
            _httpClientFactory = httpClientFactory;
            _productQueryRepository = productQueryRepository;
        }

        public async Task CreateCustomerAllAsync(CreateCustomerAllCommand request, CancellationToken cancellationToken)
        {
            var company = _companyQueryRepository.GetAll();
            List<Customer> customers = new List<Customer>();
            foreach (var item in company)
            {
                _context = (CompanyDbContext)_contextService.CreateDbContextInstance(item.Id);
                _commandRepository.SetDbContextInstance(_context);
                _unitOfWork.SetDbContextInstance(_context);

                var client = _httpClientFactory.CreateClient();
                string apiUrl = item.ClientApiUrl;
                string requestUrl = $"{apiUrl}/BasketRobot/GetAllCustomer";
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var queryResponse = JsonSerializer.Deserialize<List<Customer>>(responseBody, options);
                    customers = queryResponse;
                    customers.Select(x => x.Id = Guid.NewGuid().ToString()).ToList();
                    await _commandRepository.AddRangeAsync(customers, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    customers.Clear();
                }
            }

            return;
        }

        public async Task CreateCustomerCompanyAsync(CreateCustomerCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var ClientApiURL = _companyQueryRepository.GetById(request.companyId, false).Result.ClientApiUrl;
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            List<Customer> customers = new List<Customer>();
            var client = _httpClientFactory.CreateClient();
            string apiUrl = ClientApiURL;
            string requestUrl = $"{apiUrl}/BasketRobot/GetAllCustomer";
            var response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseBody = await response.Content.ReadAsStringAsync();
                var queryResponse = JsonSerializer.Deserialize<List<Customer>>(responseBody, options);
                customers = queryResponse;
                customers.Select(x => x.Id = Guid.NewGuid().ToString()).ToList();
                await _commandRepository.AddRangeAsync(customers, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Customer> CreateCustomerAsync(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Customer entity = _mapper.Map<Customer>(request);
            entity.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public async Task<IList<Customer>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().OrderBy(p => p.Name).ToListAsync();
        }
        public async Task<Customer> GetByCustomerCodeAsync(string companyId, string name,
            CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetFirstByExpiression(p => p.Name == name, cancellationToken);
        }
        public async Task<Customer> GetByIdAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetById(id);
        }
        public async Task<Customer> RemoveByIdCustomerAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            Customer entity = await _queryRepository.GetById(id);
            _commandRepository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Customer customer, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(customer);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
