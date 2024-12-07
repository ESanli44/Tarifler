using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;

namespace Tarifler.Web.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IService<Mesaj> _sevice;
        private readonly IMapper _mapper;

        public IletisimController(IService<Mesaj> sevice, IMapper mapper)
        {
            _sevice = sevice;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(IletisimViewModel model)
        {
            var iletisim = _mapper.Map<Mesaj>(model);
            if (ModelState.IsValid)
            {
                try
                {
                    await _sevice.AddAsync(iletisim);
                    TempData["Durum"] = "Mesajınız Başarıyla Gönderilmiştir..";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Durum"] = "Mesajınız Gönderilmemiştir...";
                }
            }
            return View(model);
            return View();
        }

    }
}
