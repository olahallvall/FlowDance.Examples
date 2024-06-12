using BookingService.Models;
using BookingService.Services;
using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
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

        [HttpPost("booktrip")]
        public async Task<IActionResult> BookTrip([FromBody] Trip trip)
        {
            var traceId = Guid.NewGuid();
            
            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5112/api/Compensating/compensate"), traceId, _loggerFactory))
            {
                using var db = new TripContext();
       
                db.Add(trip);

                //db.ChangeTracker.DetectChanges();
                //var shortView = db.ChangeTracker.DebugView.ShortView;
                //var longView = db.ChangeTracker.DebugView.LongView;

                await db.SaveChangesAsync();

                //compSpan.AddCompensationData(shortView, "ShortView");
                //compSpan.AddCompensationData(longView, "LongView");
                compSpan.AddCompensationData(trip.TripId.ToString(), "TripId");

                // Book a Car
                await _carService.BookCar(trip.PassportNumber, trip.TripId, traceId);

                compSpan.Complete();
            }

            return Ok(trip);
        }
    }
}
