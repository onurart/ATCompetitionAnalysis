using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Features.AppFeatures.Auth.Commands.Login
{
    public class LoginCommand
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
