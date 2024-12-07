using Tarifler.Core.Entity;

namespace Tarifler.Web.Models
{
    public class BannerViewModel
    {
        public List<YemekTarif> Yemekler { get; set;}
        public List<Kategori> Kategoriler { get; set; }
    }
}
