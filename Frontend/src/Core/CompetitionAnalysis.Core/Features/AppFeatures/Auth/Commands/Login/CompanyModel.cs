using Newtonsoft.Json;

namespace CompetitionAnalysis.Core.Features.AppFeatures.Auth.Commands.Login
{
    public class CompanyModel
    {
        [JsonProperty("CompanyId")] // Match the JSON property name "CompanyId" with this property

        public string CompanyId { get; set; }
    }
}
