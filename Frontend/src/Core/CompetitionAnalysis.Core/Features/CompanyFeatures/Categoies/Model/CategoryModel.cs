using CompetitionAnalysis.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CompetitionAnalysis.Core.Features.CompanyFeatures.Categoies.Model
{
    public class CategoryModel : Entity
    {
     
        [Key]
        public string Id { get; set; }
        public string CategoryName { get; set; }

    }
}
