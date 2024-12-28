using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // kontrol
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            
            return Ok();
        }
    }
}
