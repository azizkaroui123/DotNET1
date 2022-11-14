using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ENISNC;
using ENISNC.Models;

namespace ENISNC.Controllers
{
    public class DemandePFEsController : Controller
    {
        private readonly ENISContext _context;

        public DemandePFEsController(ENISContext context)
        {
            _context = context;
        }

        // GET: DemandePFEs
        public async Task<IActionResult> Index()
        {
              return View(await _context.DemandePFE.ToListAsync());
        }

        // GET: DemandePFEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DemandePFE == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.DemandePFE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandePFE == null)
            {
                return NotFound();
            }

            return View(demandePFE);
        }

        // GET: DemandePFEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemandePFEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,date,description,Status,demanded_at,approved_at")] DemandePFE demandePFE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demandePFE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demandePFE);
        }

        // GET: DemandePFEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DemandePFE == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.DemandePFE.FindAsync(id);
            if (demandePFE == null)
            {
                return NotFound();
            }
            return View(demandePFE);
        }

        // POST: DemandePFEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,description,Status,demanded_at,approved_at")] DemandePFE demandePFE)
        {
            if (id != demandePFE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demandePFE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandePFEExists(demandePFE.Id))
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
            return View(demandePFE);
        }

        // GET: DemandePFEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DemandePFE == null)
            {
                return NotFound();
            }

            var demandePFE = await _context.DemandePFE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demandePFE == null)
            {
                return NotFound();
            }

            return View(demandePFE);
        }

        // POST: DemandePFEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DemandePFE == null)
            {
                return Problem("Entity set 'ENISContext.DemandePFE'  is null.");
            }
            var demandePFE = await _context.DemandePFE.FindAsync(id);
            if (demandePFE != null)
            {
                _context.DemandePFE.Remove(demandePFE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandePFEExists(int id)
        {
          return _context.DemandePFE.Any(e => e.Id == id);
        }
    }
}
