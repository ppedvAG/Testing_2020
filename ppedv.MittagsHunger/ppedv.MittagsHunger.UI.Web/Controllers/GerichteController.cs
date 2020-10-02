using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.UI.Web.Data;

namespace ppedv.MittagsHunger.UI.Web.Controllers
{
    public class GerichteController : Controller
    {
        private readonly ppedvMittagsHungerUIWebContext _context;

        public GerichteController(ppedvMittagsHungerUIWebContext context)
        {
            _context = context;
        }

        // GET: Gerichte
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gericht.ToListAsync());
        }

        // GET: Gerichte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gericht = await _context.Gericht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gericht == null)
            {
                return NotFound();
            }

            return View(gericht);
        }

        // GET: Gerichte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerichte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Preis,KCal,Vegetarisch,Id,Created,Modified")] Gericht gericht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gericht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gericht);
        }

        // GET: Gerichte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gericht = await _context.Gericht.FindAsync(id);
            if (gericht == null)
            {
                return NotFound();
            }
            return View(gericht);
        }

        // POST: Gerichte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Preis,KCal,Vegetarisch,Id,Created,Modified")] Gericht gericht)
        {
            if (id != gericht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gericht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerichtExists(gericht.Id))
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
            return View(gericht);
        }

        // GET: Gerichte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gericht = await _context.Gericht
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gericht == null)
            {
                return NotFound();
            }

            return View(gericht);
        }

        // POST: Gerichte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gericht = await _context.Gericht.FindAsync(id);
            _context.Gericht.Remove(gericht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerichtExists(int id)
        {
            return _context.Gericht.Any(e => e.Id == id);
        }
    }
}
