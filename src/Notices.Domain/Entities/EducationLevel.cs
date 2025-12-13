using System.ComponentModel.DataAnnotations;

namespace Notices.Domain.Entities;

public enum EducationLevel
{
    [Display(Name = "Podstawówka (1-3)")]
    Podstawowka13 = 1,
    
    [Display(Name = "Podstawówka (4-6)")]
    Podstawowka46 = 2,

    [Display(Name = "Podstawówka (7-8)")]
    Klasy7_8 = 3,

    [Display(Name = "Liceum")]
    Liceum = 4,
    
    [Display(Name = "Przygotowanie do matury podstawowej")]
    PrzygotowanieDoMaturyPodstawowej = 5,
    
    [Display(Name = "Przygotowanie do matury rozszerzonej")]
    PrzygotowanieDoMaturyRozszerzonej = 6,
    
    [Display(Name = "Studia")]
    Studia
}