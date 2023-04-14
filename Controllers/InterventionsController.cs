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
    public class InterventionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterventionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interventions
        public async Task<IActionResult> Index()
        {
              return _context.Interventions != null ? 
                          View(await _context.Interventions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Interventions'  is null.");
        }

        // GET: Interventions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions
                .FirstOrDefaultAsync(m => m.InterventionId == id);
            if (interventions == null)
            {
                return NotFound();
            }

            return View(interventions);
        }

        // GET: Interventions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interventions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterventionId,TypeIntervention")] Interventions interventions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interventions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interventions);
        }

        // GET: Interventions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }
            return View(interventions);
        }

        // POST: Interventions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterventionId,TypeIntervention")] Interventions interventions)
        {
            if (id != interventions.InterventionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interventions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterventionsExists(interventions.InterventionId))
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
            return View(interventions);
        }

        // GET: Interventions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions
                .FirstOrDefaultAsync(m => m.InterventionId == id);
            if (interventions == null)
            {
                return NotFound();
            }

            return View(interventions);
        }

        // POST: Interventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Interventions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Interventions'  is null.");
            }
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions != null)
            {
                _context.Interventions.Remove(interventions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterventionsExists(int id)
        {
          return (_context.Interventions?.Any(e => e.InterventionId == id)).GetValueOrDefault();
        }
    }
}
