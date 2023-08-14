using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;
namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
       private readonly MyWorldDbContext _myWorldDbContext;
        public BookController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookSListAsync() { 
        var books=await
                _myWorldDbContext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("/get-by-id")]
        public async Task<IActionResult> GetBookByID(int id) { 
        var book=await
                _myWorldDbContext.Books.FindAsync(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddingBooks(Book book) { 
            _myWorldDbContext.Books.Add(book);
            await _myWorldDbContext.SaveChangesAsync();
            return Created($"/get-by-id?id={book.id}",book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookDetails(Book book) {
            _myWorldDbContext.Books.Add(book);
            await _myWorldDbContext.SaveChangesAsync(); 
            return NoContent();
        }

        [HttpDelete]
        [Route("/give-id-to-delete-book")]
        public async Task<IActionResult> DeletingBook(int id) {
            var deletableBook = await _myWorldDbContext.Books.FindAsync(id);
            if (deletableBook == null)
            {
                return NotFound(id);
            }
            _myWorldDbContext.Books.Remove(deletableBook);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }
      }
}
