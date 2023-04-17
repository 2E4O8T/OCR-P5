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
    public class InventairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventaires
        public async Task<IActionResult> Index()
        {
              return _context.Inventaires != null ? 
                          View(await _context.Inventaires.Include(i => i.Reparations).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Inventaires'  is null.");
        }

        // GET: Inventaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .FirstOrDefaultAsync(m => m.CodeVin == id);
            if (inventaire == null)
            {
                return NotFound();
            }

            return View(inventaire);
        }

        // GET: Inventaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CodeVin,Annee,Marque,Modele,Finition,DateAchat,PrixAchat,PrixVente,DateVente,IsVente,Description,Photo")] Inventaire inventaire)
        public async Task<IActionResult> Create([Bind("CodeVin,Annee,Marque,Modele,Finition,DateAchat,PrixAchat,PrixVente,DateVente,IsVente")] Inventaire inventaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventaire);
        }

        // GET: Inventaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire == null)
            {
                return NotFound();
            }
            return View(inventaire);
        }

        // POST: Inventaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeVin,Annee,Marque,Modele,Finition,DateAchat,PrixAchat,PrixVente,DateVente,IsVente,Description,Photo")] Inventaire inventaire)
        {
            if (id != inventaire.CodeVin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventaireExists(inventaire.CodeVin))
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
            return View(inventaire);
        }

        // GET: Inventaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .FirstOrDefaultAsync(m => m.CodeVin == id);
            if (inventaire == null)
            {
                return NotFound();
            }

            return View(inventaire);
        }

        // POST: Inventaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventaires == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inventaires'  is null.");
            }
            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire != null)
            {
                _context.Inventaires.Remove(inventaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventaireExists(int id)
        {
          return (_context.Inventaires?.Any(e => e.CodeVin == id)).GetValueOrDefault();
        }
    }
}
