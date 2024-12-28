using BookStoreApp.Context;
using BookStoreApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                _context.Books.Add(book);
                return StatusCode(201, book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBookById([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            //CHECK BOOK
            var entity =_context.Books.Find(b => book.Id == book.Id);
            if (entity is null)
            {
                return NotFound(); // 400
            }
            // CHECK ID
            if (id != book.Id)
            {
                return BadRequest("ivalid argumnet");// 404
            }
            _context.Books.Remove(entity);
            book.Id = entity.Id;
            // added to List
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            _context.Books.Clear();
            _context.SaveChanges();
            return NoContent();// 204
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBookById([FromRoute(Name = "id")] int id)
        {
            var entity = _context.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }

           _context.Books.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PatchBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            // check
            var entity = _context.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }
            bookPatch.ApplyTo(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}