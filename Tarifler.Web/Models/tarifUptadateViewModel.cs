using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack;
using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class tarifUptadateViewModel
    {
        public int TarifId { get; set; }
        public string Baslik { get; set; }
        public int Sure { get; set; }
        public string Malzeme { get; set; }
        [ValidateNever]
        public string? Resim { get; set; }
        public string? Aciklama { get; set; }
        public string? kisiSayisi { get; set; }
        public string TarifAciklama { get; set; }
        public bool IsActive { get; set; }

        [ValidateNever]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ValidateNever]
        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        [ValidateNever]
        public int? TurId { get; set; }
        public Tur Tur { get; set; }

        public List<Begeni> Begeniler { get; set; } = new List<Begeni>();

        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
