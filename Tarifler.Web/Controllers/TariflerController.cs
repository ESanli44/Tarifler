using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        private readonly IService<Begeni> _serviceBegeni;
        private readonly IMapper _mapper;

        public TariflerController(IService<YemekTarif> serviceTarif, IMapper mapper, IService<Kategori> serviceKategori, IService<Yorum> serviceYorum, IService<Begeni> serviceBegeni)
        {
            _serviceTarif = serviceTarif;
            _mapper = mapper;
            _serviceKategori = serviceKategori;
            _serviceYorum = serviceYorum;
            _serviceBegeni = serviceBegeni;
        }

        public IActionResult Index(string Ara="",int page=1)
        {
            if (Ara != null)
            {
                var kart = new KartFiltreViewModel()
                {
                    Arama = Ara,
                    PageNumber = page,
                    isim ="Tarifler"
                };
                ViewData["kart"] = kart;

            }
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
                .Include(y => y.Yorumlar).ThenInclude(x=>x.User)
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
            var yorum = _serviceYorum.GetQueryable().OrderByDescending(x=>x.YorumId).Take(1).Select(x=>x.YorumId);
            int yorumId = 0;
            foreach (int num in yorum)
            {
                yorumId = int.Parse(num.ToString());
            }

            //return Redirect("/Tarifler/Detay/" + TarifId );
            return Json(new {
                yorumId,
                username,
                Text,
                entity.YayinTarihi,
            });
        }
       
        public async Task<IActionResult> YorumSil(int YorumId)
        {
            var kayit = await _serviceYorum.GetFindAsync(YorumId);
            await _serviceYorum.DeleteAsync(kayit);

            return Json(new
            {
                YorumId,               
            });
        }

        public async Task<IActionResult> Kategori(int id=0, string Ara = "",int page=1)
        {
            var kategori = await _serviceKategori.GetAllAsync();

            var kart = new KartFiltreViewModel()
            {
                Arama = Ara,
                Kategori = id,
                isim = "Tarifler/Kategori",
                PageNumber = page
            };
            ViewData["kart"] = kart;

            return View(new KategoriViewvModel() { Kategoriler = kategori });
           
        }

        public async Task<IActionResult> Begen(int TarifId)
        {
            bool deger = false;
            var userId = int.Parse(User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
            var yemek = await _serviceBegeni.GetFirstAsync(x => x.YemekTarifId == TarifId && x.UserId == userId);

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
    }
}
