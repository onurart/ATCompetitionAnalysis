using System.ComponentModel.DataAnnotations;

namespace CompetitionAnalysis.Domain.Enums
{
    public enum Specieses
    {
        [Display(Name = "Diğer")]
        Dıger = 0,
        [Display(Name = "Kampanya")]
        Kampanya=10,
        [Display(Name = "Fiyat İskontosu")]
        Fiyatİskontosu=20,
        [Display(Name = "Ödeme Şekli")]
        odemeSekli=30,

    }
}
