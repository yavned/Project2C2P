using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2C2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(long? customerID, string email)
        {
            return Ok();
        }

    }
}
