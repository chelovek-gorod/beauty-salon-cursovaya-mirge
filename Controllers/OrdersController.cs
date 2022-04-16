#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BeautySalonContext _context;

        public OrdersController(BeautySalonContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(DateTime OrdersFrom, DateTime OrdersTo)
        {
            DateTime zeroDate = new DateTime(0001, 1, 1, 0, 0, 0);
            
            var orders = from ord in _context.Order
                         select ord;

            if (OrdersFrom <= OrdersTo && OrdersTo > zeroDate)
            {
                orders = orders.Where(ord => ord.OrderDate <= OrdersTo && ord.OrderDate >= OrdersFrom);
            }

            var beautySalonContext = orders.Include(o => o.Client).Include(o => o.Employee).Include(o => o.Service);

            return View(await beautySalonContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.Service)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "FullName");
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FullName");
            ViewData["ServiceID"] = new SelectList(_context.Service, "ServiceID", "ServiceName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ClientID,EmployeeID,OrderDate,ServiceID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "FullName", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FullName", order.EmployeeID);
            ViewData["ServiceID"] = new SelectList(_context.Service, "ServiceID", "ServiceName", order.ServiceID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "FullName", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FullName", order.EmployeeID);
            ViewData["ServiceID"] = new SelectList(_context.Service, "ServiceID", "ServiceName", order.ServiceID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,ClientID,EmployeeID,OrderDate,ServiceID")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "FullName", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "FullName", order.EmployeeID);
            ViewData["ServiceID"] = new SelectList(_context.Service, "ServiceID", "ServiceName", order.ServiceID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.Service)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
