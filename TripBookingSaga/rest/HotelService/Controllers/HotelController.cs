using FlowDance.Client;
using FlowDance.Client.AspNetCore.ActionFilters;
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

        [CompensationSpan(CompensatingActionUrl = "http://localhost:5075/api/Compensating/compensate")]
        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel([FromBody] Hotel hotel)
        {
            // Access the CompensationSpan instance from the ActionFilter
            var compensationSpan = HttpContext.Items["CompensationSpan"] as CompensationSpan;

            // Book a flight
            var retval = await _flightService.BookFlight(hotel.PassportNumber, hotel.TripId, compensationSpan.TraceId);

            return Ok();
        }
    }
}
