using BookingService.Models;
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

        public BookingController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        [HttpPost("booktrip")]
        public async Task<IActionResult> BookTrip([FromBody] Trip trip)
        {
            var traceId = Guid.NewGuid();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5112/api/Compensating/compensate"), traceId, _loggerFactory))
            {
                using var db = new TripContext();
                db.Add(new Trip() { CarId = trip.CarId, PassportNumber = trip.PassportNumber });
                await db.SaveChangesAsync();

                db.ChangeTracker.DetectChanges();
                compSpan.AddCompensationData(db.ChangeTracker.DebugView.ShortView, "ShortView");
                compSpan.AddCompensationData(db.ChangeTracker.DebugView.LongView, "LongView");

                //compSpan.Complete();
            }

            return Ok();
        }
    }
}
