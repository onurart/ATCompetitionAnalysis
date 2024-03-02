using CompetitionAnalysis.Application.Messaging;
namespace CompetitionAnalysis.Application.Features.CompanyFeatures.Campaign.Commands.CreateCampaign;
public sealed record CreateCampaignCommand
                                        (
                                         string Name,
                                         decimal Price,
                                         DateTime StartDate,
                                         DateTime EndDate,
                                         string ImageUrl,
                                         string BrandId,
                                         string CategoryId,
                                         string ProductId,
                                         string CompanyId,
                                         string CustomerId): ICommand<CreateCampaignCommandResponse>;
