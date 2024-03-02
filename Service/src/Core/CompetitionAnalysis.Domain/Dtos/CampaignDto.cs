namespace CompetitionAnalysis.Domain.Dtos;
public class CampaignDto
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Price { get; set; }
   
    public DateTime? CreatedDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }


    public string? CustomerName { get; set; }
    public string? ProductName { get; set; }
    public string? CategoryName { get; set; }
    public string? BrandName { get; set; }

    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public string? CategoryId { get; set; }
    public string? BrandId { get; set; }
}
