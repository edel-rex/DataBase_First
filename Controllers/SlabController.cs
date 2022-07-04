using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proj1.Models;

namespace Proj1.Controllers
{
    public class SlabController : Controller
    {
        private readonly Electricity_BillContext _context;

        public SlabController(Electricity_BillContext context)
        {
            _context = context;
        }

        // GET: Slab
        public async Task<IActionResult> Index()
        {
            var electricity_BillContext = _context.Slabs.Include(s => s.ConnectionType);
            return View(await electricity_BillContext.ToListAsync());
        }

        // GET: Slab/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs
                .Include(s => s.ConnectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slab == null)
            {
                return NotFound();
            }

            return View(slab);
        }

        // GET: Slab/Create
        public IActionResult Create()
        {
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id");
            return View();
        }

        // POST: Slab/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConnectionTypeId,FromUnit,ToUnit,Rate")] Slab slab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", slab.ConnectionTypeId);
            return View(slab);
        }

        // GET: Slab/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs.FindAsync(id);
            if (slab == null)
            {
                return NotFound();
            }
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", slab.ConnectionTypeId);
            return View(slab);
        }

        // POST: Slab/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConnectionTypeId,FromUnit,ToUnit,Rate")] Slab slab)
        {
            if (id != slab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlabExists(slab.Id))
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
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", slab.ConnectionTypeId);
            return View(slab);
        }

        // GET: Slab/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slabs == null)
            {
                return NotFound();
            }

            var slab = await _context.Slabs
                .Include(s => s.ConnectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slab == null)
            {
                return NotFound();
            }

            return View(slab);
        }

        // POST: Slab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slabs == null)
            {
                return Problem("Entity set 'Electricity_BillContext.Slabs'  is null.");
            }
            var slab = await _context.Slabs.FindAsync(id);
            if (slab != null)
            {
                _context.Slabs.Remove(slab);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlabExists(int id)
        {
          return (_context.Slabs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
