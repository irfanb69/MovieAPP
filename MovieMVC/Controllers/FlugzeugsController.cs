using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Datas;
using MovieMVC.Models;

namespace MovieMVC.Controllers
{
    public class FlugzeugsController : Controller
    {
        private readonly MovieMVCContext _context;

        public FlugzeugsController(MovieMVCContext context)
        {
            _context = context;
        }

        // GET: Flugzeugs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flugzeugs.ToListAsync());
        }

        // GET: Flugzeugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flugzeug = await _context.Flugzeugs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flugzeug == null)
            {
                return NotFound();
            }

            return View(flugzeug);
        }

        // GET: Flugzeugs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flugzeugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Flugzeug flugzeug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flugzeug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flugzeug);
        }

        // GET: Flugzeugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flugzeug = await _context.Flugzeugs.FindAsync(id);
            if (flugzeug == null)
            {
                return NotFound();
            }
            return View(flugzeug);
        }

        // POST: Flugzeugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Flugzeug flugzeug)
        {
            if (id != flugzeug.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flugzeug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlugzeugExists(flugzeug.Id))
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
            return View(flugzeug);
        }

        // GET: Flugzeugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flugzeug = await _context.Flugzeugs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flugzeug == null)
            {
                return NotFound();
            }

            return View(flugzeug);
        }

        // POST: Flugzeugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flugzeug = await _context.Flugzeugs.FindAsync(id);
            _context.Flugzeugs.Remove(flugzeug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlugzeugExists(int id)
        {
            return _context.Flugzeugs.Any(e => e.Id == id);
        }
    }
}
