using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using HotelService.Models;
using HotelService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IFlightService _flightService;

        public HotelController(ILoggerFactory iloggerFactory, IFlightService flightService)
        {
            _loggerFactory = iloggerFactory;  
            _flightService = flightService;
        }

        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel([FromBody] Hotel hotel)
        {
            var b1 = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            var b2 = Guid.TryParse(correlationId, out var traceId);
            if (!b1 || !b2) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5075/api/Compensating/compensate"), Guid.Parse(correlationId), _loggerFactory))
            {

                // Book a flight
                await _flightService.BookFlight(hotel.PassportNumber, hotel.TripId, traceId);

                compSpan.Complete();
            }

            return Ok();
        }
    }
}
