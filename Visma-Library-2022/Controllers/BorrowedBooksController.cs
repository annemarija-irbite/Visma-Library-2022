#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Visma_Library_2022.Data;
using Visma_Library_2022.Models;

namespace Visma_Library_2022.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<SelectListItem> AspNetUsers { get; set; }

        private IEnumerable GetAllUserId()
        {

            return _context.Users.ToList().Select(users => new SelectListItem
            {
                Text = users.Id.ToString(),
                Value = users.Id.ToString()
            });
        }

        public BorrowedBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BorrowedBooks
        public async Task<IActionResult> Index()
        {
            var model = await _context.BorrowedBook
                                        .Where(a => a.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                                        .ToListAsync();
            return View(model);

            //return View(await _context.BorrowedBook.ToListAsync());
        }

        // GET: BorrowedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook.FindAsync(id);

            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }
        [Authorize]
        // GET: BorrowedBooks/Create
        public IActionResult Create(int bookId)
        {
            BorrowedBook model = new BorrowedBook();
            
            model.ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.BookId = bookId;
            
            return View(model);
        }

        // POST: BorrowedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowHistoryId,BookId,ApplicationUserId,BorrowDate,ReturnDate")] BorrowedBook borrowedBook)
        {
            _context.Add(borrowedBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            //AspNetUsers = (IEnumerable<SelectListItem>)GetAllUserId();
            //ViewBag.Users = AspNetUsers;
            //ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", borrowedBook.BookId);
            //return View(borrowedBook);
        }

        // GET: BorrowedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook.FindAsync(id);

            if (borrowedBook == null)
            {
                return NotFound();
            }
            //ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "ApplicationUserID ", "Id", borrowedBook.ApplicationUserID);
            //ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", borrowedBook.BookId);
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowHistoryId,BookId,ApplicationUserId,BorrowDate,ReturnDate")] BorrowedBook borrowedBook)
        {
            if (id != borrowedBook.BorrowHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowedBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowedBookExists(borrowedBook.BorrowHistoryId))
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
            //ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", borrowedBook.ApplicationUserID);
            //ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", borrowedBook.BookId);
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook.FirstOrDefaultAsync(m => m.BorrowHistoryId == id);
            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowedBook = await _context.BorrowedBook.FindAsync(id);
            _context.BorrowedBook.Remove(borrowedBook);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowedBookExists(int id)
        {
            return _context.BorrowedBook.Any(e => e.BorrowHistoryId == id);
        }
    }
}
