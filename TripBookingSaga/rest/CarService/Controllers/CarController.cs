using CarService.Models;
using CarService.Services;
using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHotelService _hotelService;

        public CarController(ILoggerFactory iloggerFactory, IHotelService hotelService)
        {
            _loggerFactory = iloggerFactory;
            _hotelService = hotelService;
        }

        [HttpPost("bookcar")]
        public async Task<IActionResult> BookCar([FromBody] Car car)
        {
            var b1 = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            var b2 = Guid.TryParse(correlationId, out var traceId);
            if (!b1 || !b2) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5043/api/Compensating/compensate"), traceId, _loggerFactory))
            {
                // Book a Hotel
                await _hotelService.BookHotel(car.PassportNumber, car.TripId, traceId);

                compSpan.Complete();
            }

            return Ok();
        }
    }
}
