using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifler.Core.Entity
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string? KategoriAciklama { get; set; }

        public List<YemekTarif>? YemekTarifleri { get; set; } = new List<YemekTarif>();
    }
}
