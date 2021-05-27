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
    public class OrderExecutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderExecutorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderExecutors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orderExecutors.Include(o => o.Executor).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderExecutors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecutor = await _context.orderExecutors
                .Include(o => o.Executor)
                .Include(o => o.Order)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (orderExecutor == null)
            {
                return NotFound();
            }

            return View(orderExecutor);
        }

        // GET: OrderExecutors/Create
        public IActionResult Create()
        {
            ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Name");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name");
            return View();
        }

        // POST: OrderExecutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ExecutorId")] OrderExecutor orderExecutor)
        {
            if(orderExecutor.OrderId==null && orderExecutor.ExecutorId == null)
            {
                ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Name");
                ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name");
                return View(orderExecutor);
            }

            orderExecutor.Id = Guid.NewGuid();
            _context.Add(orderExecutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: OrderExecutors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecutor = await _context.orderExecutors.SingleOrDefaultAsync(m => m.Id == id);
            if (orderExecutor == null)
            {
                return NotFound();
            }
            ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Name", orderExecutor.ExecutorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name", orderExecutor.OrderId);
            return View(orderExecutor);
        }

        // POST: OrderExecutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderId,ExecutorId")] OrderExecutor orderExecutor)
        {
            if (id != orderExecutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderExecutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExecutorExists(orderExecutor.Id))
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
            ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Name", orderExecutor.ExecutorId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Name", orderExecutor.OrderId);
            return View(orderExecutor);
        }

        // GET: OrderExecutors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecutor = await _context.orderExecutors
                .Include(o => o.Executor)
                .Include(o => o.Order)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (orderExecutor == null)
            {
                return NotFound();
            }

            return View(orderExecutor);
        }

        // POST: OrderExecutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orderExecutor = await _context.orderExecutors.SingleOrDefaultAsync(m => m.Id == id);
            _context.orderExecutors.Remove(orderExecutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExecutorExists(Guid id)
        {
            return _context.orderExecutors.Any(e => e.Id == id);
        }
    }
}
