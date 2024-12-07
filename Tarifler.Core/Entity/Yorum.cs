using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Yorum
    {
        public int YorumId { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinTarihi { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? YemekTarifId { get; set; }
        public YemekTarif YemekTarif { get; set; }
    }
}
