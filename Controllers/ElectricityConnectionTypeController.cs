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
    public class ElectricityConnectionTypeController : Controller
    {
        private readonly Electricity_BillContext _context;

        public ElectricityConnectionTypeController(Electricity_BillContext context)
        {
            _context = context;
        }

        // GET: ElectricityConnectionType
        public async Task<IActionResult> Index()
        {
              return _context.ElectricityConnectionTypes != null ? 
                          View(await _context.ElectricityConnectionTypes.ToListAsync()) :
                          Problem("Entity set 'Electricity_BillContext.ElectricityConnectionTypes'  is null.");
        }

        // GET: ElectricityConnectionType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ElectricityConnectionTypes == null)
            {
                return NotFound();
            }

            var electricityConnectionType = await _context.ElectricityConnectionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electricityConnectionType == null)
            {
                return NotFound();
            }

            return View(electricityConnectionType);
        }

        // GET: ElectricityConnectionType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ElectricityConnectionType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConnectionName")] ElectricityConnectionType electricityConnectionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electricityConnectionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electricityConnectionType);
        }

        // GET: ElectricityConnectionType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ElectricityConnectionTypes == null)
            {
                return NotFound();
            }

            var electricityConnectionType = await _context.ElectricityConnectionTypes.FindAsync(id);
            if (electricityConnectionType == null)
            {
                return NotFound();
            }
            return View(electricityConnectionType);
        }

        // POST: ElectricityConnectionType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConnectionName")] ElectricityConnectionType electricityConnectionType)
        {
            if (id != electricityConnectionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electricityConnectionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectricityConnectionTypeExists(electricityConnectionType.Id))
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
            return View(electricityConnectionType);
        }

        // GET: ElectricityConnectionType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ElectricityConnectionTypes == null)
            {
                return NotFound();
            }

            var electricityConnectionType = await _context.ElectricityConnectionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (electricityConnectionType == null)
            {
                return NotFound();
            }

            return View(electricityConnectionType);
        }

        // POST: ElectricityConnectionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ElectricityConnectionTypes == null)
            {
                return Problem("Entity set 'Electricity_BillContext.ElectricityConnectionTypes'  is null.");
            }
            var electricityConnectionType = await _context.ElectricityConnectionTypes.FindAsync(id);
            if (electricityConnectionType != null)
            {
                _context.ElectricityConnectionTypes.Remove(electricityConnectionType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectricityConnectionTypeExists(int id)
        {
          return (_context.ElectricityConnectionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
