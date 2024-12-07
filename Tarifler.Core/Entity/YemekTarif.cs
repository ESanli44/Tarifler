using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class YemekTarif
    {
        [Key]
        public int TarifId { get; set; }
        public string Baslik { get; set; }
        public int Sure { get; set; }
        public string Malzeme { get; set; }
        public string? Resim { get; set; }
        public string? Aciklama { get; set; } 
        public string? kisiSayisi { get; set; } 
        public string TarifAciklama { get; set; }        
        public bool IsActive { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        public int? TurId { get; set; }
        public Tur Tur { get; set; }

        public List<Begeni> Begeniler { get; set; } = new List<Begeni>();

        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();

        public List<Like> Likes { get; set; } = new List<Like>();


    }
}
