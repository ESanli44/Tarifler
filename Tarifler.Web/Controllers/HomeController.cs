using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System.Diagnostics;
using Tarifler.Core.Entity;
using Tarifler.Data;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;

namespace Tarifler.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Begeni> _serviceBegeni;
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<Slider> _serviceSlider;

        public HomeController(IService<Begeni> serviceBegeni, IService<YemekTarif> serviceTarif, IService<Slider> serviceSlider)
        {
            _serviceBegeni = serviceBegeni;
            _serviceTarif = serviceTarif;
            _serviceSlider = serviceSlider;
        }

        public async Task<IActionResult> Index(string ara="",int page=1)
        {
            if (ara != null)
            {
                var kart = new KartFiltreViewModel()
                {
                    Arama = ara,
                    PageNumber = page,
                    isim = "Home"
                };
                ViewData["kart"] = kart;

            }

            return View();
        }

        public async Task<IActionResult> Slider(int id)
        {
            var slider = await _serviceSlider.GetFirstAsync(x=>x.SliderId == id);
            return View(slider);
        }
        public  async Task<IActionResult> Begen(int TarifId)
        {
            bool deger = false;
            var userId = int.Parse(User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
            var yemek = await _serviceBegeni.GetFirstAsync(x=>x.YemekTarifId == TarifId && x.UserId == userId);
            
            if (yemek != null)
            {
                await _serviceBegeni.DeleteAsync(yemek);
                deger = false;
            }
            else
            {
                var begeni = new Begeni()
                {
                    Begen = true,
                    UserId = userId,
                    YemekTarifId = TarifId,
                };

                await _serviceBegeni.AddAsync(begeni);
                deger = true;
            }

            return Json(new
            {
                deger,
            });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
