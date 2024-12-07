using Tarifler.Core.Entity;

namespace Tarifler.Web.Areas.Admin.Models
{
    public class MainModelView
    {
       public List<YemekTarif> yemekTarifleri {  get; set; }
       public List<User> Kullanicilar { get; set; }
       public List<Mesaj> Mesajlar { get; set; }
    }
}
