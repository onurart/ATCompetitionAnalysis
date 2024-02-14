﻿using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductCompany;
using CompetitionAnalysis.Application.Services.CompanyServices;
using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.AppDbContext.CompanyRepositories;
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
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CompetitionAnalysis.Persistance.Services.CompanyServices
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICompanyQueryRepository _companyQueryRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private CompanyDbContext _context;
        public ProductService(IProductCommandRepository commandRepository, IProductQueryRepository queryRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper, ICompanyQueryRepository companyQueryRepository, IHttpClientFactory httpClientFactory)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _companyQueryRepository = companyQueryRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateProductAll(CreateProductAllCommand request, CancellationToken cancellationToken)
        {
            var company = _companyQueryRepository.GetAll();
            List<Product> products = new List<Product>();
            foreach (var item in company)
            {
                _context = (CompanyDbContext)_contextService.CreateDbContextInstance(item.Id);
                _commandRepository.SetDbContextInstance(_context);
                _unitOfWork.SetDbContextInstance(_context);
                var client = _httpClientFactory.CreateClient();
                string apiUrl = item.ClientApiUrl;
                string requestUrl = $"{apiUrl}/BasketRobot/GetAllProducts";
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var queryResponse = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(responseBody, options);
                    products = queryResponse;
                    products.Select(x => x.Id = Guid.NewGuid().ToString()).ToList();
                    products.Select(x => x.IsDelete = false).ToList();
                    await _commandRepository.AddRangeAsync(products, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    products.Clear();
                }
            }
            return;
        }

        public async Task<Product> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Product product = _mapper.Map<Product>(request);
            await _commandRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task CreateProductCompany(CreateProductCompanyCommand request, CancellationToken cancellationToken)
        {
            var ClientApiURL = _companyQueryRepository.GetById(request.companyId, false).Result.ClientApiUrl;
            List<Product> products = new List<Product>();

            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.companyId);
            _commandRepository.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            var masterproducts = _queryRepository.GetAll(false).ToList();
            var client = _httpClientFactory.CreateClient();
            string apiUrl = ClientApiURL;
            string requestUrl = $"{apiUrl}/BasketRobot/GetAllProducts";
            var response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                string responseBody = await response.Content.ReadAsStringAsync();
                var queryResponse = JsonSerializer.Deserialize<List<Product>>(responseBody, options);
                products = queryResponse;
                products.Select(x => x.Id = Guid.NewGuid().ToString()).ToList();
                products.Select(x => x.IsDelete = false).ToList();
                await _commandRepository.AddRangeAsync(products, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<IList<Product>> GetAllAsync(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetAll().AsNoTracking().ToListAsync();
        }
        public async Task<Product> GetByIdAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetById(id);
        }
        public async Task<Product> GetByProductCodeAsync(string companyId, string productcode, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetFirstByExpiression(p => p.Name == productcode, cancellationToken);
        }
        public async Task<Product> RemoveByIdProductAsync(string id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            Product product = await _queryRepository.GetById(id);
            _commandRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }
        public async Task UpdateAsync(Product product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _commandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Product> UpdateProductIsActiveAsync(string id, string companyId, bool isActive)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            Product product = await _queryRepository.GetById(id);
            product.IsActive = isActive;
            _commandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }
    }
}