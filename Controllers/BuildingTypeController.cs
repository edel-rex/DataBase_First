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
    public class BuildingTypeController : Controller
    {
        private readonly Electricity_BillContext _context;

        public BuildingTypeController(Electricity_BillContext context)
        {
            _context = context;
        }

        // GET: BuildingType
        public async Task<IActionResult> Index()
        {
            var electricity_BillContext = _context.BuildingTypes.Include(b => b.ConnectionType);
            return View(await electricity_BillContext.ToListAsync());
        }

        // GET: BuildingType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .Include(b => b.ConnectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // GET: BuildingType/Create
        public IActionResult Create()
        {
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id");
            return View();
        }

        // POST: BuildingType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ConnectionTypeId")] BuildingType buildingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", buildingType.ConnectionTypeId);
            return View(buildingType);
        }

        // GET: BuildingType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType == null)
            {
                return NotFound();
            }
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", buildingType.ConnectionTypeId);
            return View(buildingType);
        }

        // POST: BuildingType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ConnectionTypeId")] BuildingType buildingType)
        {
            if (id != buildingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingTypeExists(buildingType.Id))
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
            ViewData["ConnectionTypeId"] = new SelectList(_context.ElectricityConnectionTypes, "Id", "Id", buildingType.ConnectionTypeId);
            return View(buildingType);
        }

        // GET: BuildingType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuildingTypes == null)
            {
                return NotFound();
            }

            var buildingType = await _context.BuildingTypes
                .Include(b => b.ConnectionType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // POST: BuildingType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuildingTypes == null)
            {
                return Problem("Entity set 'Electricity_BillContext.BuildingTypes'  is null.");
            }
            var buildingType = await _context.BuildingTypes.FindAsync(id);
            if (buildingType != null)
            {
                _context.BuildingTypes.Remove(buildingType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingTypeExists(int id)
        {
          return (_context.BuildingTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
