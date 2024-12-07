using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarifler.Core.Entity;
using Tarifler.Data;

namespace Tarifler.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class TurlerController : Controller
    {
        private readonly TarifDbContext _context;

        public TurlerController(TarifDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Turler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turler.ToListAsync());
        }

        // GET: Admin/Turler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tur = await _context.Turler
                .FirstOrDefaultAsync(m => m.TurId == id);
            if (tur == null)
            {
                return NotFound();
            }

            return View(tur);
        }

        // GET: Admin/Turler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Turler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurId,TurAdi,TurAciklama")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tur);
        }

        // GET: Admin/Turler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tur = await _context.Turler.FindAsync(id);
            if (tur == null)
            {
                return NotFound();
            }
            return View(tur);
        }

        // POST: Admin/Turler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurId,TurAdi,TurAciklama")] Tur tur)
        {
            if (id != tur.TurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurExists(tur.TurId))
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
            return View(tur);
        }

        // GET: Admin/Turler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tur = await _context.Turler
                .FirstOrDefaultAsync(m => m.TurId == id);
            if (tur == null)
            {
                return NotFound();
            }

            return View(tur);
        }

        // POST: Admin/Turler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tur = await _context.Turler.FindAsync(id);
            if (tur != null)
            {
                _context.Turler.Remove(tur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurExists(int id)
        {
            return _context.Turler.Any(e => e.TurId == id);
        }
    }
}
