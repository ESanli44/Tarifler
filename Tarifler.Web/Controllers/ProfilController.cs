using AutoMapper;
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
        private readonly IMapper _mapper;


        public ProfilController(IService<YemekTarif> serviceTarif, IService<User> serviceUser, IMapper mapper, IService<Kategori> serviceKategori, IService<Tur> serviceTur)
        {
            _serviceTarif = serviceTarif;
            _serviceUser = serviceUser;
            _mapper = mapper;
            _serviceKategori = serviceKategori;
            _serviceTur = serviceTur;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var Id = HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            string reqValue = Id.Value;
            var user = await _serviceUser.GetFindAsync(int.Parse(reqValue));
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

            var tarif = _mapper.Map<YemekViewModel>(yemekTarif);
            return View(tarif);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, YemekViewModel model, IFormFile Image)
        {
            var yemekTarif = _mapper.Map<YemekTarif>(model);
            if (id != yemekTarif.TarifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    yemekTarif.IsActive = false;
                    yemekTarif.UserId = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);
                    yemekTarif.Resim = await FileHelper.FileLoaderAsync(Image, "/img/Tarif/");
                    await _serviceTarif.UpdateAsync(yemekTarif);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemekTarifExists(yemekTarif.TarifId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi", yemekTarif.TurId);

            return View(yemekTarif);
        }
        private bool YemekTarifExists(int id)
        {
            return _serviceTarif.GetQueryable().Any(e => e.TarifId == id);
        }
    }
}
