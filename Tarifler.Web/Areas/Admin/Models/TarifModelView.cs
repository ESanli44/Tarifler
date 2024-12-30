using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tarifler.Core.Entity;

namespace Tarifler.Web.Areas.Admin.Models
{
    public class TarifModelView
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int TarifId { get; set; }

        [Required(ErrorMessage ="Zorunlu Alan")]
        [Display(Name ="Tarif İsmi")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarif Süresi")]
        public int Sure { get; set; }
        public string? Aciklama { get; set; }
        public string? kisiSayisi { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Malzeme { get; set; }

        [BindNever]
        [ValidateNever]
        [Display(Name = "Resim")]
        public string? Resim { get; set; }
       

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarifin Yapılışı")]
        public string TarifAciklama { get; set; }

        [DefaultValue(false)] 
        public bool IsActive { get; set; }
        //---------------------------------------------------------------
        [ValidateNever]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Kimin Tarifi")]
        public int? UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarifin Kategorisi")]
        [ValidateNever]
        public int? KategoriId { get; set; }
        [ValidateNever]
        public Kategori Kategori { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarifin Türü")]
        [ValidateNever]
        public int? TurId { get; set; }
        [ValidateNever]
        public Tur Tur { get; set; }

    }
}
