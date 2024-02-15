using AutoMapper;
using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CompetitionAnalysis.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductCompany;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerCompany;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship;
using CompetitionAnalysis.Persistance.Configurations;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationship;

namespace CompetitionAnalysis.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<CreateRoleCommand, AppRole>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateProductAllCommand, List<Product>>();
            CreateMap<CreateProductCompanyCommand, List<Product>>();

            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<CreateCustomerAllCommand, List<Customer>>();
            CreateMap<CreateCustomerCompanyCommand, List<Customer>>();



            CreateMap<GetAllProductCustomerRelationshipQuery, ProductCustomerRelationshipses>();
        }
    }
}
