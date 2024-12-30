using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class YorumViewModel
    {
        public int YorumId { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int begeniSayisi { get; set; }
        public int yorumSayisi { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? YemekTarifId { get; set; }
        public YemekTarif YemekTarif { get; set; }
    }
}
