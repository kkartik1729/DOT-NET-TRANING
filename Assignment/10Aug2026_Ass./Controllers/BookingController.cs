using _10Aug2026.Models;
using _10Aug2026.Services;
using Microsoft.AspNetCore.Mvc;

namespace _10Aug2026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            try
            {
                var result = bookingService.CreateBooking(booking);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}