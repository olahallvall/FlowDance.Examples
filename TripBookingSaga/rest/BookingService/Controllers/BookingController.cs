using BookingService.Models;
using BookingService.Services;
using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using FlowDance.Common.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly CarService _carService;

        public BookingController(ILoggerFactory loggerFactory, CarService carService)
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
                var tripEntity = new Trip() { CarId = trip.CarId, PassportNumber = trip.PassportNumber };
                db.Add(tripEntity);

                db.ChangeTracker.DetectChanges();
                var shortView = db.ChangeTracker.DebugView.ShortView;
                var longView = db.ChangeTracker.DebugView.LongView;

                await db.SaveChangesAsync();

                compSpan.AddCompensationData(tripEntity.TripId.ToString(), "TripId");
                compSpan.AddCompensationData(shortView, "ShortView");
                compSpan.AddCompensationData(longView, "LongView");

                // Book a Car
                _carService.BookCar(trip.PassportNumber, tripEntity.TripId, traceId);

                compSpan.Complete();
            }

            return Ok();
        }
    }
}
