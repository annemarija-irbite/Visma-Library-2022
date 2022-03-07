#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Visma_Library_2022.Data;
using Visma_Library_2022.Models;

namespace Visma_Library_2022.Controllers
{
    public class BookReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookReservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookReservation.Include(b => b.ApplicationUser).Include(b => b.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservation
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (bookReservation == null)
            {
                return NotFound();
            }

            return View(bookReservation);
        }

        // GET: BookReservations/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            return View();
        }

        // POST: BookReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,UserId,BookId,DateTo")] BookReservation bookReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", bookReservation.UserId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", bookReservation.BookId);
            return View(bookReservation);
        }

        // GET: BookReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservation.FindAsync(id);
            if (bookReservation == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", bookReservation.UserId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", bookReservation.BookId);
            return View(bookReservation);
        }

        // POST: BookReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,UserId,BookId,DateTo")] BookReservation bookReservation)
        {
            if (id != bookReservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookReservationExists(bookReservation.ReservationId))
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
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", bookReservation.UserId);
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", bookReservation.BookId);
            return View(bookReservation);
        }

        // GET: BookReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookReservation = await _context.BookReservation
                .Include(b => b.ApplicationUser)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (bookReservation == null)
            {
                return NotFound();
            }

            return View(bookReservation);
        }

        // POST: BookReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookReservation = await _context.BookReservation.FindAsync(id);
            _context.BookReservation.Remove(bookReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookReservationExists(int id)
        {
            return _context.BookReservation.Any(e => e.ReservationId == id);
        }
    }
}
