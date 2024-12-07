using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;

namespace Tarifler.Web.ViewComponents
{
    public class KartViewComponent : ViewComponent
    {
        private readonly IService<YemekTarif> _service;

        public KartViewComponent(IService<YemekTarif> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string deger)
        {
            if (!string.IsNullOrEmpty(deger))
            {
                var kart = await _service.GetQueryable().Where(c => c.IsActive == true && c.Baslik == deger)
                .Include(x => x.Tur)
                .Include(x => x.Kategori)
                .Include(x => x.User)
                .ToListAsync();

                return View(kart);
            }
            else
            {
                var kart = await _service.GetQueryable().Where(c => c.IsActive == true)
                .Include(x => x.Tur)
                .Include(x => x.Kategori)
                .Include(x => x.User)
                .ToListAsync();

                return View(kart);
            }

           
        }
    }
}
