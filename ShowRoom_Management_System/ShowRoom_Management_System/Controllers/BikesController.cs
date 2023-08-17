using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShowRoom_Management_System.Data;
using ShowRoom_Management_System.Models;

namespace ShowRoom_Management_System.Controllers
{
    public class BikesController : Controller
    {
        private readonly ShowRoom_Management_SystemContext _context;

        public BikesController(ShowRoom_Management_SystemContext context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
              return _context.Bikes != null ? 
                          View(await _context.Bikes.ToListAsync()) :
                          Problem("Entity set 'ShowRoom_Management_SystemContext.Bikes'  is null.");
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }

            var bikes = await _context.Bikes
                .FirstOrDefaultAsync(m => m.ChasisNo == id);
            if (bikes == null)
            {
                return NotFound();
            }

            return View(bikes);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChasisNo,BikeName,Brand,ManufactureYear,Colour,isElectric")] Bikes bikes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikes);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }

            var bikes = await _context.Bikes.FindAsync(id);
            if (bikes == null)
            {
                return NotFound();
            }
            return View(bikes);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChasisNo,BikeName,Brand,ManufactureYear,Colour,isElectric")] Bikes bikes)
        {
            if (id != bikes.ChasisNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikesExists(bikes.ChasisNo))
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
            return View(bikes);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }

            var bikes = await _context.Bikes
                .FirstOrDefaultAsync(m => m.ChasisNo == id);
            if (bikes == null)
            {
                return NotFound();
            }

            return View(bikes);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bikes == null)
            {
                return Problem("Entity set 'ShowRoom_Management_SystemContext.Bikes'  is null.");
            }
            var bikes = await _context.Bikes.FindAsync(id);
            if (bikes != null)
            {
                _context.Bikes.Remove(bikes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikesExists(int id)
        {
          return (_context.Bikes?.Any(e => e.ChasisNo == id)).GetValueOrDefault();
        }
    }
}
