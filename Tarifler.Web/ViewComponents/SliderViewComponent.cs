using Microsoft.AspNetCore.Mvc;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;

namespace Tarifler.Web.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly IService<Slider> _service;

        public SliderViewComponent(IService<Slider> service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slider = _service.GetAll().OrderByDescending(x => x.SliderId).Take(3);
            return View(slider);
        }
    }
}
