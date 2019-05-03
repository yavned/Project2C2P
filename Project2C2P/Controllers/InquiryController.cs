using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2C2P.Models;
using Project2C2P.Services;

namespace Project2C2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private IInquiryService _service;

        public InquiryController(IInquiryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long? customerID, string email)
        {
            if (customerID != null)
            {
                InquiryView result = await _service.GetByCustomerID((long)customerID);

                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            if (!String.IsNullOrEmpty(email))
            {
                InquiryView result = await _service.GetByEmail(email);

                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            return BadRequest("No inquiry criteria");
        }

    }
}
