using System.Collections.Generic;
using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class KategoriViewvModel
    {
        public List<YemekTarif>? Yemekler { get; set; }
        public List<Kategori>? Kategoriler { get; set; }
    }


    
}
