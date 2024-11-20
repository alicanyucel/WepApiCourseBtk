using HelloWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result= new ResponseModel() {

                Id = 1,
                Message = "MERHABA"
                
            };
            return Ok(result);
        }
    }
}
