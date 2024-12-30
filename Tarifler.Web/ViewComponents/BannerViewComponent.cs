using Microsoft.AspNetCore.Mvc;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;

namespace Tarifler.Web.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<Kategori> _serviceKategori;

        public BannerViewComponent(IService<YemekTarif> serviceTarif, IService<Kategori> serviceKategori)
        {
            _serviceTarif = serviceTarif;
            _serviceKategori = serviceKategori;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var yBanner = _serviceTarif.GetAllWhere(x=>x.IsActive==true).OrderByDescending(x => x.TarifId).Take(4);
            var kBanner = await _serviceKategori.GetAllAsync();
            
            var model = new BannerViewModel(){
                Kategoriler = kBanner,
                Yemekler = yBanner.ToList(),
            };

            return View(model);
        }
    }
}
