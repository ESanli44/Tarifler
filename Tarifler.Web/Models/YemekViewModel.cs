using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class YemekViewModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int TarifId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarif İsmi")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Tarif Süresi")]
        public int Sure { get; set; }

        public string? Aciklama { get; set; }
        public string? kisiSayisi { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Malzeme { get; set; }

        public string? Resim { get; set; }
        public FormFile? Image { get; set; }

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

        public List<Begeni>? Begeniler { get; set; } = new List<Begeni>();

        public List<Yorum>? Yorumlar { get; set; } = new List<Yorum>();
    }
}
