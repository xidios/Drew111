using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend6.Data;
using Backend6.Models;

namespace Backend6.Controllers
{
    public class ExecutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExecutorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Executors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Executors.ToListAsync());
        }

        // GET: Executors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // GET: Executors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Executors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position")] Executor executor)
        {
            if (ModelState.IsValid)
            {
                executor.Id = Guid.NewGuid();
                _context.Add(executor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(executor);
        }

        // GET: Executors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.Id == id);
            if (executor == null)
            {
                return NotFound();
            }
            return View(executor);
        }

        // POST: Executors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Position")] Executor executor)
        {
            if (id != executor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(executor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecutorExists(executor.Id))
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
            return View(executor);
        }

        // GET: Executors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors
                .SingleOrDefaultAsync(m => m.Id == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // POST: Executors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var executor = await _context.Executors.SingleOrDefaultAsync(m => m.Id == id);
            _context.Executors.Remove(executor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecutorExists(Guid id)
        {
            return _context.Executors.Any(e => e.Id == id);
        }
    }
}
