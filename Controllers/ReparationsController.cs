using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVSec.Data;
using EVSec.Models;

namespace EVSec.Controllers
{
    public class ReparationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reparations.Include(r => r.Inventaire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reparations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations
                .Include(r => r.Inventaire)
                .FirstOrDefaultAsync(m => m.ReparationId == id);
            if (reparations == null)
            {
                return NotFound();
            }

            return View(reparations);
        }

        // GET: Reparations/Create
        public IActionResult Create()
        {
            ViewData["InventaireId"] = new SelectList(_context.Inventaires, "CodeVin", "CodeVin");
            return View();
        }

        // POST: Reparations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReparationId,InventaireId,DateDisponibilite,CoutReparation")] Reparations reparations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["InventaireId"] = new SelectList(_context.Inventaires, "CodeVin", "Finition", reparations.InventaireId);
            return View(reparations);
        }

        // GET: Reparations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations.FindAsync(id);
            if (reparations == null)
            {
                return NotFound();
            }
            //ViewData["InventaireId"] = new SelectList(_context.Inventaires, "CodeVin", "Finition", reparations.InventaireId);
            return View(reparations);
        }

        // POST: Reparations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReparationId,InventaireId,DateDisponibilite,CoutReparation")] Reparations reparations)
        {
            if (id != reparations.ReparationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationsExists(reparations.ReparationId))
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
            ViewData["InventaireId"] = new SelectList(_context.Inventaires, "CodeVin", "Finition", reparations.InventaireId);
            return View(reparations);
        }

        // GET: Reparations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparations = await _context.Reparations
                .Include(r => r.Inventaire)
                .FirstOrDefaultAsync(m => m.ReparationId == id);
            if (reparations == null)
            {
                return NotFound();
            }

            return View(reparations);
        }

        // POST: Reparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reparations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reparations'  is null.");
            }
            var reparations = await _context.Reparations.FindAsync(id);
            if (reparations != null)
            {
                _context.Reparations.Remove(reparations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparationsExists(int id)
        {
          return (_context.Reparations?.Any(e => e.ReparationId == id)).GetValueOrDefault();
        }
    }
}
