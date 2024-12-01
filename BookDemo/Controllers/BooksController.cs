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
        [HttpGet]
    }
}