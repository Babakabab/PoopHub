using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoopHub.Data;
using PoopHub.Models;

namespace PoopHub.Controllers
{
    public class ToiletsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToiletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Toilets
        public async Task<IActionResult> Index()
        {
              return _context.Toilet != null ? 
                          View(await _context.Toilet.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Toilet'  is null.");
        }

        // GET: Toilets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Toilet == null)
            {
                return NotFound();
            }

            var toilet = await _context.Toilet
                .FirstOrDefaultAsync(m => m.id == id);
            if (toilet == null)
            {
                return NotFound();
            }

            return View(toilet);
        }

        // GET: Toilets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Toilets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreatedAt,UpdatedAt,id")] Toilet toilet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toilet);
        }

        // GET: Toilets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Toilet == null)
            {
                return NotFound();
            }

            var toilet = await _context.Toilet.FindAsync(id);
            if (toilet == null)
            {
                return NotFound();
            }
            return View(toilet);
        }

        // POST: Toilets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CreatedAt,UpdatedAt,id")] Toilet toilet)
        {
            if (id != toilet.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToiletExists(toilet.id))
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
            return View(toilet);
        }

        // GET: Toilets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Toilet == null)
            {
                return NotFound();
            }

            var toilet = await _context.Toilet
                .FirstOrDefaultAsync(m => m.id == id);
            if (toilet == null)
            {
                return NotFound();
            }

            return View(toilet);
        }

        // POST: Toilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Toilet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Toilet'  is null.");
            }
            var toilet = await _context.Toilet.FindAsync(id);
            if (toilet != null)
            {
                _context.Toilet.Remove(toilet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToiletExists(long id)
        {
          return (_context.Toilet?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
