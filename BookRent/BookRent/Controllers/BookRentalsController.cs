using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookRent.Data;
using BookRent.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookRent.Controllers
{
    public class BookRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookRentals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookRentals.Include(b => b.Books).Include(b => b.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookRentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRentals = await _context.BookRentals
                .Include(b => b.Books)
                .Include(b => b.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookRentals == null)
            {
                return NotFound();
            }

            return View(bookRentals);
        }

        // GET: BookRentals/Create
        public IActionResult CreateAdmin()
       {
           ViewData["BookId"] = new SelectList(_context.Bookss, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
           return View();
       } 

        [Authorize]
        public IActionResult Create(int id)
        {
            // ViewData["BookId"] = new SelectList(_context.Bookss.Where(b => b.Id == id), "BkName");
            ViewData["BookId"] = new SelectList(_context.Bookss.Where(b => b.Id == id), "Id", "Id", id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["UserId"] = new SelectList(new[] { userId });
            ViewData["UserId"] = new SelectList(_context.Users.Where(b => b.Id == userId), "Id", "Id");
            return View();
        }



        // POST: BookRentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalStart,RentalEnd,BookId,UserId")] BookRentals bookRentals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookRentals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Bookss, "Id", "Id", bookRentals.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bookRentals.UserId);
            return View(bookRentals);
        }

        // GET: BookRentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRentals = await _context.BookRentals.FindAsync(id);
            if (bookRentals == null)
            {
                return NotFound();
            }

            var books = _context.Bookss.Select(a => new SelectListItem(a.BkName, a.Id.ToString())).ToList();
            ViewData["BookId"] = books;
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bookRentals.UserId);
            return View();
        }

        // POST: BookRentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentalStart,RentalEnd,BookId,UserId")] BookRentals bookRentals)
        {
            if (id != bookRentals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookRentals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookRentalsExists(bookRentals.Id))
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
            ViewData["BookId"] = new SelectList(_context.Bookss, "Id", "Id", bookRentals.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bookRentals.UserId);
            return View(bookRentals);
        }

        // GET: BookRentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRentals = await _context.BookRentals
                .Include(b => b.Books)
                .Include(b => b.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookRentals == null)
            {
                return NotFound();
            }

            return View(bookRentals);
        }

        // POST: BookRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookRentals = await _context.BookRentals.FindAsync(id);
            _context.BookRentals.Remove(bookRentals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookRentalsExists(int id)
        {
            return _context.BookRentals.Any(e => e.Id == id);
        }
    }
}
