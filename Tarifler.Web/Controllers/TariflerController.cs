using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Models;
using Tarifler.Web.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace Tarifler.Web.Controllers
{
    public class TariflerController : Controller
    {
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<Kategori> _serviceKategori;
        private readonly IService<Yorum> _serviceYorum;
        private readonly IMapper _mapper;

        public TariflerController(IService<YemekTarif> serviceTarif, IMapper mapper, IService<Kategori> serviceKategori, IService<Yorum> serviceYorum)
        {
            _serviceTarif = serviceTarif;
            _mapper = mapper;
            _serviceKategori = serviceKategori;
            _serviceYorum = serviceYorum;
        }

        public IActionResult Index(string Ara="")
        {
            TempData["Ara"]=Ara;
            return View();
        }

        public async Task<IActionResult> Detay(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _serviceTarif.GetQueryable()
                .Include(y => y.Kategori)
                .Include(y => y.Tur)
                .Include(y => y.User)
                .Include(y => y.Yorumlar)
                .FirstOrDefaultAsync(m => m.TarifId == id);

            if (yemekTarif == null)
            {
                return NotFound();
            }
            var tarif = _mapper.Map<YemekViewModel>(yemekTarif);
            return View(tarif);
        }

        public async Task<IActionResult> YorumEkle(int TarifId, string Text)
        {
           
            var username = User.FindFirstValue(ClaimTypes.Name);
            var userId = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);

            var entity = new Yorum
            {
                YemekTarifId = TarifId,
                YayinTarihi = DateTime.Now,
                Icerik = Text,                
                UserId = userId
            };

            await _serviceYorum.AddAsync(entity);

            return RedirectToAction("Detay");
        }
        public async Task<IActionResult> Kategori(int id=0, string Ara = "")
        {
            if (id==0)
            {
                TempData["Ara"] = Ara;
                var kategori = await _serviceKategori.GetAllAsync();

                var yemek = _serviceTarif.GetQueryable()
                .Include(y => y.User)
                .Include(k => k.Kategori)
                .ToList();

                return View(new KategoriViewvModel() { Kategoriler = kategori, Yemekler = yemek });
            }
            else
            {
                TempData["Ara"] = Ara;
                var kategori = await _serviceKategori.GetAllAsync();

                var yemek = _serviceTarif.GetQueryable()
                .Include(y => y.User)
                .Include(k => k.Kategori)
                .Where(k => k.KategoriId == id).ToList();

                return View(new KategoriViewvModel() { Kategoriler = kategori, Yemekler = yemek });
            }
                         
        }


    }
}
