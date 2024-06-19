using CarService.Models;
using CarService.Services;
using FlowDance.Client;
using FlowDance.Client.AspNetCore.ActionFilters;
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

        [CompensationSpan(CompensatingActionUrl = "http://localhost:5043/api/Compensating/compensate")]
        [HttpPost("bookcar")]
        public async Task<IActionResult> BookCar([FromBody] Car car)
        {
            // Access the CompensationSpan instance from the ActionFilter
            var compensationSpan = HttpContext.Items["CompensationSpan"] as CompensationSpan;

            // Book a Hotel
            await _hotelService.BookHotel(car.PassportNumber, car.TripId, compensationSpan.TraceId);

            return Ok();
        }
    }
}
