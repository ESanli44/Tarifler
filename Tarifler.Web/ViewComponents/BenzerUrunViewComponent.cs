using Microsoft.AspNetCore.Mvc;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;

namespace Tarifler.Web.ViewComponents
{
    public class BenzerUrunViewComponent : ViewComponent
    {
        private readonly IService<YemekTarif> _serviceYmek;

        public BenzerUrunViewComponent(IService<YemekTarif> serviceYmek)
        {
            _serviceYmek = serviceYmek;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id=1)
        {
            var benzer =  _serviceYmek.GetAllWhere(x => x.TurId == id).Take(4).ToList();
            return View(benzer);
        }
    }
}
