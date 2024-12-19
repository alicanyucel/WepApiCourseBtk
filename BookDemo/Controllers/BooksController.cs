using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BookDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationDbContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationDbContext.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                ApplicationDbContext.Books.Add(book);
                return StatusCode(201, book);
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
            var entity = ApplicationDbContext.Books.Find(b=>book.Id==book.Id);
            if (entity is null)
            {
                return NotFound(); // 400
            }
            // CHECK ID
            if (id != book.Id)
            {
                return BadRequest("ivalid argumnet");// 404
            }
            ApplicationDbContext.Books.Remove(entity);
            book.Id = entity.Id;
            // added to List
            ApplicationDbContext.Books.Add(book);

            return Ok(book);
        }
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationDbContext.Books.Clear(); 
            return NoContent();// 204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBookById([FromRoute(Name = "id")]int id)
        {
            var entity=ApplicationDbContext.Books.Find(b=>b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound(); 
            }

            ApplicationDbContext.Books.Remove(entity);
            return NoContent();
        }

    }
}