using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Application.Features.AppFeatures.AuthFeatures.Commands.ChangePassword
{
    public sealed record ChangePasswordCommandResponse2(string Message = "Kullanıcı Şifresi Değiştirme Başarısız!");
}
