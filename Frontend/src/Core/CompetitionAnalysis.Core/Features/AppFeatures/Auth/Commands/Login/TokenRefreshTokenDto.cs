using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.AppFeatures.Auth.Commands.Login
{
    public class TokenRefreshTokenDto
    {
        public TokenModel Token { get; set; }
        [JsonProperty("Companies")] // Match the JSON property name "Companies" with this property

        public List<CompanyModel> Companies { get; set; }
        public string MainRole { get; set; }
    }
}
