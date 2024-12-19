using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok (books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")]int id)
        {
            var book=ApplicationDbContext.Books.Where(b=>b.Id.Equals(id)).SingleOrDefault();
            if(book is null)
            {
                return NotFound();
            }
            return Ok (book);
        }
    }
}