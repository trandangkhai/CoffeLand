using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeLand.Data;
using CoffeLand.Models;

namespace CoffeLand.Controllers
{
    public class CoffesController : Controller
    {
        private readonly CoffeLandContext _context;

        public CoffesController(CoffeLandContext context)
        {
            _context = context;
        }

        // GET: Coffes
        public async Task<IActionResult> Index(string coffeGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Coffe
                                            orderby b.Genre
                                            select b.Genre;
            var coffes = from b in _context.Coffe
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                coffes = coffes.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(coffeGenre))
            {
                coffes = coffes.Where(x => x.Genre == coffeGenre);
            }
            var coffeGenreVM = new CoffeGenreViewModel
            {
                Genres = new SelectList(await
            genreQuery.Distinct().ToListAsync()),
                Coffes = await coffes.ToListAsync()
            };
            return View(coffeGenreVM);
        }

        public async Task<IActionResult> Index2(string coffeGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Coffe
                                            orderby b.Genre
                                            select b.Genre;
            var coffes = from b in _context.Coffe
                         select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                coffes = coffes.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(coffeGenre))
            {
                coffes = coffes.Where(x => x.Genre == coffeGenre);
            }
            var coffeGenreVM = new CoffeGenreViewModel
            {
                Genres = new SelectList(await
            genreQuery.Distinct().ToListAsync()),
                Coffes = await coffes.ToListAsync()
            };
            return View(coffeGenreVM);
        }

        // GET: Coffes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // GET: Coffes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Coffe coffe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffe);
        }

        // GET: Coffes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe.FindAsync(id);
            if (coffe == null)
            {
                return NotFound();
            }
            return View(coffe);
        }

        // POST: Coffes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Coffe coffe)
        {
            if (id != coffe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeExists(coffe.Id))
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
            return View(coffe);
        }

        // GET: Coffes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // POST: Coffes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffe = await _context.Coffe.FindAsync(id);
            _context.Coffe.Remove(coffe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeExists(int id)
        {
            return _context.Coffe.Any(e => e.Id == id);
        }
    }
}
