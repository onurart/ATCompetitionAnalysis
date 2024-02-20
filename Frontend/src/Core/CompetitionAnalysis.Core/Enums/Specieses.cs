using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionAnalysis.Core.Enums
{
    public enum Specieses
    {
        [Display(Name = "Diğer")]
        Dıger = 0,
        [Display(Name = "Kampanya")]
        Kampanya = 10,
        [Display(Name = "Fiyat İskontosu")]
        Fiyatİskontosu = 20,
        [Display(Name = "Ödeme Şekli")]
        odemeSekli = 30,
    }
}
