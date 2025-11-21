using System.ComponentModel.DataAnnotations;

namespace Notices.Domain.Entities;

public enum EducationLevel
{
    [Display(Name = "Klasy 1-3")]
    Podstawowka13,
    
    [Display(Name = "Klasy 4-6")]
    Podstawowka46,

    [Display(Name = "Klasy 7–8")]
    Klasy7_8,

    [Display(Name = "Liceum")]
    Liceum,
    
    [Display(Name = "Przygotowanie do matury podstawowej")]
    PrzygotowanieDoMaturyPodstawowej,
    
    [Display(Name = "Przygotowanie do matury rozszerzonej")]
    PrzygotowanieDoMaturyRozszerzonej,
    
    [Display(Name = "Studia")]
    Studia
}