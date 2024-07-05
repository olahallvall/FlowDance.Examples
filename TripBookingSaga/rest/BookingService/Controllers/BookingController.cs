using BookingService.Models;
using BookingService.Services;
using FlowDance.Client;
using FlowDance.Common.Enums;
using FlowDance.Client.AspNetCore.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ICarService _carService;

        public BookingController(ILoggerFactory loggerFactory, ICarService carService)
        {
            _loggerFactory = loggerFactory;
            _carService = carService;
        }

        [CompensationSpan(CompensatingActionUrl = "http://host.docker.internal:5112/api/Compensating/compensate", CompensationSpanOption = CompensationSpanOption.RequiresNewBlockingCallChain)]
        [HttpPost("booktrip")]
        public async Task<IActionResult> BookTrip([FromBody] Trip trip)
        {
            // Access the CompensationSpan instance from the ActionFilter
            var compensationSpan = HttpContext.Items["CompensationSpan"] as CompensationSpan;
            
            using var db = new TripContext();
       
            db.Add(trip);

            db.ChangeTracker.DetectChanges();
            var shortView = db.ChangeTracker.DebugView.ShortView;
            var longView = db.ChangeTracker.DebugView.LongView;

            await db.SaveChangesAsync();

            compensationSpan.AddCompensationData(shortView, "ShortView");
            compensationSpan.AddCompensationData(longView, "LongView");
            compensationSpan.AddCompensationData(trip.TripId.ToString(), "TripId");

            // Book a Car
            await _carService.BookCar(trip.PassportNumber, trip.TripId, compensationSpan.TraceId);

            return Ok(trip);
        }
    }
}
