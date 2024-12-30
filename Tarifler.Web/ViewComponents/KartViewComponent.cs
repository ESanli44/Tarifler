using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;

namespace Tarifler.Web.ViewComponents
{
    public class KartViewComponent : ViewComponent
    {
        private readonly IService<YemekTarif> _service;

        public KartViewComponent(IService<YemekTarif> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(KartFiltreViewModel filtre)
        {
            var deger = filtre.Arama;


            if (!string.IsNullOrEmpty(deger))
            {

                var kart = await _service.GetQueryable()
                .Include(x => x.User)
                .Include(x => x.Tur)
                .Include(x => x.Kategori)                
                .Include(x => x.Yorumlar)
                .Include(x => x.Begeniler).ThenInclude(x => x.User)
                .Where(c => c.IsActive == true && c.Baslik == deger)
                .ToListAsync();

                ViewBag.toplamSayfa = _service.GetAll().Count();
                ViewBag.isim = filtre.isim;

                return View(kart);
            }
            else if(string.IsNullOrEmpty(deger) && filtre.Kategori>0)
            {
                var kart = await _service.GetQueryable()
                .Include(x => x.User)
                .Include(x => x.Tur)
                .Include(x => x.Kategori)
                .Include(x => x.Yorumlar)
                .Include(x => x.Begeniler).ThenInclude(x => x.User)
                .Where(c => c.IsActive == true && c.KategoriId==filtre.Kategori)
                .ToListAsync();

                ViewBag.toplamSayfa = _service.GetAll().Count();
                ViewBag.isim = filtre.isim;

                return View(kart);
            }
            else
            {
                var kart = await _service.GetQueryable()
                .Include(x => x.User)
                .Include(x => x.Tur)
                .Include(x => x.Kategori)              
                .Include(x => x.Yorumlar)
                .Include(x => x.Begeniler).ThenInclude(x => x.User)
                .Where(c => c.IsActive == true)
                .ToListAsync();

                ViewBag.toplamSayfa = _service.GetAll().Count();
                ViewBag.isim = filtre.isim;

                return View(kart);
            }

           
        }
    }
}
