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
    public class MeterController : Controller
    {
        private readonly Electricity_BillContext _context;

        public MeterController(Electricity_BillContext context)
        {
            _context = context;
        }

        // GET: Meter
        public async Task<IActionResult> Index()
        {
            var electricity_BillContext = _context.Meters.Include(m => m.Building);
            return View(await electricity_BillContext.ToListAsync());
        }

        // GET: Meter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meters == null)
            {
                return NotFound();
            }

            var meter = await _context.Meters
                .Include(m => m.Building)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meter == null)
            {
                return NotFound();
            }

            return View(meter);
        }

        // GET: Meter/Create
        public IActionResult Create()
        {
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Id");
            return View();
        }

        // POST: Meter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeterNumber,BuildingId")] Meter meter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Id", meter.BuildingId);
            return View(meter);
        }

        // GET: Meter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Meters == null)
            {
                return NotFound();
            }

            var meter = await _context.Meters.FindAsync(id);
            if (meter == null)
            {
                return NotFound();
            }
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Id", meter.BuildingId);
            return View(meter);
        }

        // POST: Meter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeterNumber,BuildingId")] Meter meter)
        {
            if (id != meter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeterExists(meter.Id))
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
            ViewData["BuildingId"] = new SelectList(_context.Buildings, "Id", "Id", meter.BuildingId);
            return View(meter);
        }

        // GET: Meter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meters == null)
            {
                return NotFound();
            }

            var meter = await _context.Meters
                .Include(m => m.Building)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meter == null)
            {
                return NotFound();
            }

            return View(meter);
        }

        // POST: Meter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meters == null)
            {
                return Problem("Entity set 'Electricity_BillContext.Meters'  is null.");
            }
            var meter = await _context.Meters.FindAsync(id);
            if (meter != null)
            {
                _context.Meters.Remove(meter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeterExists(int id)
        {
          return (_context.Meters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
