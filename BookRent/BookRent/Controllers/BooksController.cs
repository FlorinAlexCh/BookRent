using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookRent.Models;
using BookRent.Data;
using Microsoft.AspNetCore.Authorization;

namespace BookRent.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string SearchString)
        {
            //  var applicationDbContext = _context.Bookss.Include(b => b.Author).Include(b => b.Publisher);
            // return View(await applicationDbContext.ToListAsync());

            ViewData["Filter"] = SearchString;
            var books = from b in _context.Bookss.Include(b => b.Author).Include(b => b.Publisher) select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.BkName.Contains(SearchString));
            }
            return View(await books.ToListAsync());
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Bookss
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        [Authorize(Roles = "creator")]
        // GET: Books/Create
        public IActionResult Create()
        {
            var authors = _context.Authors.Select(a => new SelectListItem(a.Name, a.Id.ToString())).ToList();
            ViewData["AuthorID"] = authors;

            var publishers = _context.Publishers.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
            ViewData["PublisherID"] = publishers;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BkImage,BkName,BkDescription,BkPrice,BkCategory,BkReleaseYear,Quantity,BkPageNumber,BkLanguage,BkCoverType,PublisherID,AuthorID")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "Id", "Id", books.AuthorID);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", books.PublisherID);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Bookss.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "Id", "Id", books.AuthorID);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", books.PublisherID);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BkImage,BkName,BkDescription,BkPrice,BkCategory,BkReleaseYear,Quantity,BkPageNumber,BkLanguage,BkCoverType,PublisherID,AuthorID")] Books books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "Id", "Id", books.AuthorID);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", books.PublisherID);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Bookss
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Bookss.FindAsync(id);
            _context.Bookss.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Bookss.Any(e => e.Id == id);
        }
    }
}
