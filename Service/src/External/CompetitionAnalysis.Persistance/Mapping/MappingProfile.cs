using AutoMapper;
using CompetitionAnalysis.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CompetitionAnalysis.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using CompetitionAnalysis.Application.Features.CompanyFeatures.BrandFeaures.Queries.GetAllBrand;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomerCompany;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Commands.CreateProductCustomerRelationship;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductCustomerRelationship.Queries.GetAllProductCustomerRelationship;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductAll;
using CompetitionAnalysis.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProductCompany;
using CompetitionAnalysis.Domain.AppEntities;
using CompetitionAnalysis.Domain.AppEntities.Identity;
using CompetitionAnalysis.Domain.CompanyEntities;
namespace CompetitionAnalysis.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<CreateRoleCommand, AppRole>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateProductCustomerRelationshipCommand, ProductCustomerRelationshipses>();



            CreateMap<GetAllProductCustomerRelationshipQuery, ProductCustomerRelationshipses>();
            CreateMap<CreateCustomerAllCommand, List<Customer>>();
            CreateMap<CreateProductAllCommand, List<Product>>();
            CreateMap<GetAllBrandQuery, List<Brand>>();
            CreateMap<GetAllCategoryQuery, Category>();
            CreateMap<CreateProductCompanyCommand, List<Product>>();


        
        
        
        
        
        
        }
    }
}
