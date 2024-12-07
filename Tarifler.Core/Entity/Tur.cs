using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Tur
    {
        public int TurId { get; set; }
        public string TurAdi { get; set; }
        public string? TurAciklama { get; set; }

        public List<YemekTarif>? YemekTarifleri { get; set; } = new List<YemekTarif>();
    }
}
