using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RSVP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSVPController : ControllerBase
    {
        private readonly RSVPService _service;
        public RSVPController(RSVPService service)
        {
                _service = service;
        }

        [HttpPost("Personal_Information")]
        public async Task<IActionResult> ReserveASeat([FromQuery]UserRequest request)
        {
            var response = await _service.UserConfirmation(request);
            return Ok(response);
        }
        [HttpPost("Hotel_Reservation")]
        public async Task<IActionResult> BookAHotel(HotelRequest request)
        {
            var response = await _service.HotelReservation(request);
            return Ok(response);
        }
        [HttpPost("Send_A_Mail")]
        public async Task<IActionResult> BookAHotel(EmailRequest request)
        {
            var response = await _service.SendEmailAsync(request.Email, request.Subject, request.Body);
            return Ok(response);
        }
    }
}
