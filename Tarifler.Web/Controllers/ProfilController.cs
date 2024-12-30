using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tarifler.Core.Entity;
using Tarifler.Data;
using Tarifler.Service.Abstract;
using Tarifler.Web.Areas.Admin.Models;
using Tarifler.Web.Models;
using Tarifler.Web.Utils;

namespace Tarifler.Web.Controllers
{
    public class ProfilController : Controller
    {
        private readonly IService<Kategori> _serviceKategori;
        private readonly IService<Tur> _serviceTur;
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<User> _serviceUser;
        private readonly IService<Begeni> _serviceBegeni;
        private readonly IMapper _mapper;


        public ProfilController(IService<YemekTarif> serviceTarif, IService<User> serviceUser, IMapper mapper, IService<Kategori> serviceKategori, IService<Tur> serviceTur, IService<Begeni> serviceBegeni)
        {
            _serviceTarif = serviceTarif;
            _serviceUser = serviceUser;
            _mapper = mapper;
            _serviceKategori = serviceKategori;
            _serviceTur = serviceTur;
            _serviceBegeni = serviceBegeni;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var Id = HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            string reqValue = Id.Value;
            // var user = await _serviceUser.GetFindAsync(int.Parse(reqValue));
            var user = await _serviceUser.GetQueryable()
                .Include(x => x.YemekTarifleri)
                .Include(x => x.Begeniler)
                .FirstOrDefaultAsync(x => x.UserId == int.Parse(reqValue));

            TempData["Role"] = User.FindFirst(ClaimTypes.Role)?.Value;
            return View(user);
        }

        public IActionResult Yemeklerim()
        {
            var Id = HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            string reqValue = Id.Value;
            TempData["Id"] = int.Parse(reqValue);

            var data = _serviceTarif.GetQueryable()
                .Include(c => c.Kategori)
                .Include(t => t.Tur)
                .Include(u => u.User).Where(u => u.User.UserId == int.Parse(reqValue));

            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["KategoriId"] = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi");
            ViewData["TurId"] = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi");
            ViewData["UserId"] = new SelectList(_serviceUser.GetQueryable(), "UserId", "FirstName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MemberPolicy")]
        public async Task<IActionResult> Create(YemekViewModel model, IFormFile Image)
        {

            var yemekTarif = _mapper.Map<YemekTarif>(model);
            if (ModelState.IsValid)
            {
                yemekTarif.IsActive = false;
                yemekTarif.UserId = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
                yemekTarif.Resim = await FileHelper.FileLoaderAsync(Image, "/img/Tarif/");
                await _serviceTarif.AddAsync(yemekTarif);
 
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi", yemekTarif.TurId);

            return View(yemekTarif);
        }

        [Authorize(Policy = "MemberPolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _serviceTarif.GetQueryable()
                .Include(y => y.Kategori)
                .Include(y => y.Tur)
                .Include(y => y.User)
                .FirstOrDefaultAsync(m => m.TarifId == id);
            if (yemekTarif == null)
            {
                return NotFound();
            }

            return View(yemekTarif);
        }

        [Authorize(Policy = "MemberPolicy")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _serviceTarif.GetFindAsync(id);
            if (yemekTarif == null)
            {
                return NotFound();
            }

            ViewData["KategoriId"] = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi", yemekTarif.TurId);

            var tarif = _mapper.Map<tarifUptadateViewModel>(yemekTarif);
            return View(tarif);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "MemberPolicy")]
        public async Task<IActionResult> Edit(int id, tarifUptadateViewModel model, IFormFile Resim)
        {
            var yemekTarif = _mapper.Map<YemekTarif>(model);
            if (id != yemekTarif.TarifId)
            {
                return NotFound();
            }

            try
             {
               if (Resim is not null)
                    yemekTarif.Resim = await FileHelper.FileLoaderAsync(Resim, "/img/Tarif/");

                yemekTarif.IsActive = false;
                yemekTarif.UserId = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);

                await _serviceTarif.UpdateAsync(yemekTarif);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                    if (!YemekTarifExists(yemekTarif.TarifId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ViewData["KategoriId"] = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
                        ViewData["TurId"] = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi", yemekTarif.TurId);

                        return View(model);
                    }
             }
        }

        public  async Task<IActionResult> Begenilenler()
        {
            var id = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault().Value);

            var begen = _serviceBegeni.GetQueryable()
                .Include(x => x.User)
                .Include(x => x.YemekTarif).ThenInclude(x =>  x.Yorumlar)
                .Where(x => x.UserId == id).ToList();           

            var yemek = _serviceTarif.GetQueryable()
                .Include(x => x.User).ThenInclude(x=>x.Begeniler)
                .Include(x => x.Yorumlar)
                .Include(x => x.Begeniler)
                .Where(x => x.UserId == id ).ToList();

            var model = new BegeniViewModel() { begeniList = begen ,begeniSayisi=begen.Count()};

            return View(model);
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

        [HttpGet]
        public IActionResult SifreGuncelle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifreGuncelle(SifreGuncelleViewModel model)
        {
            var sifre = _mapper.Map<User>(model);

            var userId = int.Parse(User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
            var user = await _serviceUser.GetQueryable().FirstOrDefaultAsync(x => x.UserId == userId);


            if (ModelState.IsValid )
            {
                user.UserPassword = sifre.UserPassword;
                await _serviceUser.UpdateAsync(user);
                ViewBag.basarili = "Şifreniz başarılı bir şekilde değişmiştir.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.basarili = "Hatalı Şifre";
                return View(model);
            }

            
        }       

        public async Task<IActionResult> BilgilerimAsync()
        {
            var userId = int.Parse(User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
            var user = await _serviceUser.GetQueryable().FirstOrDefaultAsync(x => x.UserId == userId);

            var bilgiler = _mapper.Map<BilgilerimViewModel>(user);

            return View(bilgiler);
        }
        [HttpPost]
        public async Task<IActionResult> Bilgilerim(BilgilerimViewModel model)
        {

            var bilgiler = _mapper.Map<User>(model);
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceUser.UpdateAsync(bilgiler);
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.ToString());
                }    
                ViewBag.basarili = "Bilgileriniz Başarı ile güncellenmiştir.";
                return RedirectToAction("Index");
            }
            else {
                return View(model);
            }

                     
        }

        private bool YemekTarifExists(int id)
        {
            return _serviceTarif.GetQueryable().Any(e => e.TarifId == id);
        }

    }
}
