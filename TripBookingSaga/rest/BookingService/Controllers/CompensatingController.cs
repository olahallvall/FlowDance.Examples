using BookingService.Models;
using FlowDance.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompensatingController : ControllerBase
    {
        [HttpPost("compensate")]
        public ActionResult Compensate([FromBody] IList<SpanCompensationData> compensationData)
        {
            var b1 = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            var b2 = Guid.TryParse(correlationId, out var traceId);
            var b3 = Request.Headers.TryGetValue("x-calling-function-name", out var callingFunctionName);
            if (!b1 || !b2 || !b3) return BadRequest();

            using var db = new TripContext();

            var compensationDataTripId = compensationData.First(u => u.Identifier == "TripId");
            var tripId = Int32.Parse(compensationDataTripId.CompensationData);

            var trips = db.Trips.FirstOrDefault(u => u.TripId == tripId);
            if (trips != null)
            {
                db.Trips.Remove(trips);
            }

            db.SaveChangesAsync();

            return Ok();
        }
    }
}
