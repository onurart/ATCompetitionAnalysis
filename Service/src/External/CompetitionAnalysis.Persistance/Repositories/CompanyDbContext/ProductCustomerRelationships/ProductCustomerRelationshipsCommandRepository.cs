using CompetitionAnalysis.Domain.CompanyEntities;
using CompetitionAnalysis.Domain.Repositories.CompanyDbContext.ProductCustomerRelationships;
namespace CompetitionAnalysis.Persistance.Repositories.CompanyDbContext.ProductCustomerRelationships
{
    public sealed class ProductCustomerRelationshipsCommandRepository : CompanyDbCommandRepository<ProductCustomerRelationshipses>, IProductCustomerRelationshipCommandRepository
    {
    }
}
