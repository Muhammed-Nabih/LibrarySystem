using LibrarySystem.Data;
using LibrarySystem.Dtos;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books.Include(b => b.Category).ToListAsync();
            var bookDtos = books.Select(b => new BookDto { Id = b.Id, Title = b.Title, Author = b.Author, Category = new CategoryDto { Id = b.Category.Id, Name = b.Category.Name } }).ToList();
            return Ok(bookDtos);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDto { Id = book.Id, Title = book.Title, Author = book.Author, Category = new CategoryDto { Id = book.Category.Id, Name = book.Category.Name } };
            return Ok(bookDto);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
        {
            var category = await _context.Categories.FindAsync(bookDto.Category.Id);
            if (category == null)
            {
                return BadRequest("Invalid category ID");
            }

            var book = new Book { Title = bookDto.Title, Author = bookDto.Author, CategoryId = category.Id };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            bookDto.Id = book.Id;
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDto);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(bookDto.Category.Id);
            if (category == null)
            {
                return BadRequest("Invalid category ID");
            }

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.CategoryId = category.Id;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
