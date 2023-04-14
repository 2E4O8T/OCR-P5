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
    public class InterventionsReparationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterventionsReparationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InterventionsReparations
        public async Task<IActionResult> Index()
        {
              return _context.InterventionsReparations != null ? 
                          View(await _context.InterventionsReparations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.InterventionsReparations'  is null.");
        }

        // GET: InterventionsReparations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InterventionsReparations == null)
            {
                return NotFound();
            }

            var interventionsReparations = await _context.InterventionsReparations
                .FirstOrDefaultAsync(m => m.IntervetionsReparationsId == id);
            if (interventionsReparations == null)
            {
                return NotFound();
            }

            return View(interventionsReparations);
        }

        // GET: InterventionsReparations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterventionsReparations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntervetionsReparationsId,IntervetionsId,ReparationsId")] InterventionsReparations interventionsReparations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interventionsReparations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interventionsReparations);
        }

        // GET: InterventionsReparations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InterventionsReparations == null)
            {
                return NotFound();
            }

            var interventionsReparations = await _context.InterventionsReparations.FindAsync(id);
            if (interventionsReparations == null)
            {
                return NotFound();
            }
            return View(interventionsReparations);
        }

        // POST: InterventionsReparations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IntervetionsReparationsId,IntervetionsId,ReparationsId")] InterventionsReparations interventionsReparations)
        {
            if (id != interventionsReparations.IntervetionsReparationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interventionsReparations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterventionsReparationsExists(interventionsReparations.IntervetionsReparationsId))
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
            return View(interventionsReparations);
        }

        // GET: InterventionsReparations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InterventionsReparations == null)
            {
                return NotFound();
            }

            var interventionsReparations = await _context.InterventionsReparations
                .FirstOrDefaultAsync(m => m.IntervetionsReparationsId == id);
            if (interventionsReparations == null)
            {
                return NotFound();
            }

            return View(interventionsReparations);
        }

        // POST: InterventionsReparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InterventionsReparations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InterventionsReparations'  is null.");
            }
            var interventionsReparations = await _context.InterventionsReparations.FindAsync(id);
            if (interventionsReparations != null)
            {
                _context.InterventionsReparations.Remove(interventionsReparations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterventionsReparationsExists(int id)
        {
          return (_context.InterventionsReparations?.Any(e => e.IntervetionsReparationsId == id)).GetValueOrDefault();
        }
    }
}
