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
    public class ElectricityReadingController : Controller
    {
        private readonly Electricity_BillContext _context;

        public ElectricityReadingController(Electricity_BillContext context)
        {
            _context = context;
        }

        // GET: ElectricityReading
        public async Task<IActionResult> Index()
        {
            var electricity_BillContext = _context.ElectricityReadings.Include(e => e.Meter);
            return View(await electricity_BillContext.ToListAsync());
        }

        // GET: ElectricityReading/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ElectricityReadings == null)
            {
                return NotFound();
            }

            var electricityReading = await _context.ElectricityReadings
                .Include(e => e.Meter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electricityReading == null)
            {
                return NotFound();
            }

            return View(electricityReading);
        }

        // GET: ElectricityReading/Create
        public IActionResult Create()
        {
            ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Id");
            return View();
        }

        // POST: ElectricityReading/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeterId,Day,H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,H11,H12,H13,H14,H15,H16,H17,H18,H19,H20,H21,H22,H23,H24,TotalUnits")] ElectricityReading electricityReading)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityReading);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Id", electricityReading.MeterId);
            return View(electricityReading);
        }

        // GET: ElectricityReading/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ElectricityReadings == null)
            {
                return NotFound();
            }

            var electricityReading = await _context.ElectricityReadings.FindAsync(id);
            if (electricityReading == null)
            {
                return NotFound();
            }
            ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Id", electricityReading.MeterId);
            return View(electricityReading);
        }

        // POST: ElectricityReading/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeterId,Day,H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,H11,H12,H13,H14,H15,H16,H17,H18,H19,H20,H21,H22,H23,H24,TotalUnits")] ElectricityReading electricityReading)
        {
            if (id != electricityReading.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityReading);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityReadingExists(electricityReading.Id))
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
            ViewData["MeterId"] = new SelectList(_context.Meters, "Id", "Id", electricityReading.MeterId);
            return View(electricityReading);
        }

        // GET: ElectricityReading/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ElectricityReadings == null)
            {
                return NotFound();
            }

            var electricityReading = await _context.ElectricityReadings
                .Include(e => e.Meter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electricityReading == null)
            {
                return NotFound();
            }

            return View(electricityReading);
        }

        // POST: ElectricityReading/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ElectricityReadings == null)
            {
                return Problem("Entity set 'Electricity_BillContext.ElectricityReadings'  is null.");
            }
            var electricityReading = await _context.ElectricityReadings.FindAsync(id);
            if (electricityReading != null)
            {
                _context.ElectricityReadings.Remove(electricityReading);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityReadingExists(int id)
        {
          return (_context.ElectricityReadings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
