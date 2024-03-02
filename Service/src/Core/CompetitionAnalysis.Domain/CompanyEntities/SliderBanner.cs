using CompetitionAnalysis.Domain.Abstractions;

namespace CompetitionAnalysis.Domain.CompanyEntities
{
    public class SliderBanner : Entity
    {
        public string CampaignId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Explanation { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
