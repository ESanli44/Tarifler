using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarifler.Core.Entity;
using Tarifler.Data;
using Tarifler.Web.Areas.Admin.Models;
using Tarifler.Web.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;

namespace Tarifler.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class YemekTarifleriController : Controller
    {
        private readonly TarifDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public YemekTarifleriController(TarifDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
//--------------------------------Index----------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var tarifDbContext = _context.YemekTarifleri.Include(y => y.Kategori).Include(y => y.Tur).Include(y => y.User);
            return View(await tarifDbContext.ToListAsync());
        }
//--------------------------------Detay----------------------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _context.YemekTarifleri
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
//--------------------------------------Create---------------------------------------------------------------------
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi");
            ViewData["TurId"] = new SelectList(_context.Turler, "TurId", "TurAdi");
            ViewData["UserId"] = new SelectList(_context.Kullanicilar, "UserId", "FirstName");
            return View();
        }
        //----------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TarifModelView model, IFormFile Image)
        {
            
            var yemekTarif = _mapper.Map<YemekTarif>(model);
            if (ModelState.IsValid)
            {
                yemekTarif.Resim = await FileHelper.FileLoaderAsync(Image, "/img/Tarif/");
                _context.Add(yemekTarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_context.Turler, "TurId", "TurAdi", yemekTarif.TurId);
            ViewData["UserId"] = new SelectList(_context.Kullanicilar, "UserId", "FirstName", yemekTarif.UserId);
            return View(yemekTarif);
        }
//---------------------------Edit-----------------------------------------------------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _context.YemekTarifleri.FindAsync(id);
            if (yemekTarif == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_context.Turler, "TurId", "TurAdi", yemekTarif.TurId);
            ViewData["UserId"] = new SelectList(_context.Kullanicilar, "UserId", "FirstName", yemekTarif.UserId);

            var tarif = _mapper.Map<TarifModelView>(yemekTarif);
            return View(tarif);
        }
        //-----------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TarifModelView model, IFormFile Image)
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
                    yemekTarif.Resim = await FileHelper.FileLoaderAsync(Image, "/img/Tarif/");
                    _context.Update(yemekTarif);
                    await _context.SaveChangesAsync();
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", yemekTarif.KategoriId);
            ViewData["TurId"] = new SelectList(_context.Turler, "TurId", "TurAdi", yemekTarif.TurId);
            ViewData["UserId"] = new SelectList(_context.Kullanicilar, "UserId", "FirstName", yemekTarif.UserId);
            return View(yemekTarif);
        }
//----------------------------------Delete-------------------------------------------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yemekTarif = await _context.YemekTarifleri
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
        //-----------------------------------------------------------

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yemekTarif = await _context.YemekTarifleri.FindAsync(id);
            if (yemekTarif != null)
            {
                if (!string.IsNullOrEmpty(yemekTarif.Resim))
                {
                    FileHelper.FileRemover(yemekTarif.Resim, "/img/Tarif/");
                }
                _context.YemekTarifleri.Remove(yemekTarif);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemekTarifExists(int id)
        {
            return _context.YemekTarifleri.Any(e => e.TarifId == id);
        }
//-------------------------------------------------------------------------------------------------------------------
    }
}
