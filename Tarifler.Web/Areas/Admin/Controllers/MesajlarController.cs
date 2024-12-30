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
    public class MesajlarController : Controller
    {
        private readonly TarifDbContext _context;

        public MesajlarController(TarifDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Mesajlar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesajlar.ToListAsync());
        }

        // GET: Admin/Mesajlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajlar
                .FirstOrDefaultAsync(m => m.MesajId == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // GET: Admin/Mesajlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mesajlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MesajId,Name,Email,MesajAciklama,Durum")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesaj);
        }

        // GET: Admin/Mesajlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajlar.FindAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }
            return View(mesaj);
        }

        // POST: Admin/Mesajlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MesajId,Name,Email,MesajAciklama,Durum")] Mesaj mesaj)
        {
            if (id != mesaj.MesajId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesajExists(mesaj.MesajId))
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
            return View(mesaj);
        }

        // GET: Admin/Mesajlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajlar
                .FirstOrDefaultAsync(m => m.MesajId == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // POST: Admin/Mesajlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesaj = await _context.Mesajlar.FindAsync(id);
            if (mesaj != null)
            {
                _context.Mesajlar.Remove(mesaj);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesajExists(int id)
        {
            return _context.Mesajlar.Any(e => e.MesajId == id);
        }
    }
}
