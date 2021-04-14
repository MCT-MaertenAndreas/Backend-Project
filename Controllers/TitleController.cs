using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.IMDB
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok();
        }
    }
}
