using FlightService.Models;
using FlowDance.Client;
using FlowDance.Client.AspNetCore.ActionFilters;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {

        private readonly ILoggerFactory _loggerFactory;

        public FlightController(ILoggerFactory iloggerFactory)
        {
            _loggerFactory = iloggerFactory;
        }

        [HttpPost("bookflight")]
        public async Task<IActionResult> BookFlight([FromBody] Flight flight)
        {
            var b1 = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            var b2 = Guid.TryParse(correlationId, out var traceId);
            if (!b1 || !b2) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5113/api/Compensating/compensate"), Guid.Parse(correlationId), _loggerFactory))
            {

                // Try to book a flight
                throw new Exception("Can´t book a flight!");

                compSpan.Complete();
            }

            return Ok();
        }

        [CompensationSpan(CompensatingActionUrl = "http://localhost:5113/api/Compensating/compensate")]
        [HttpPost("bookflight2")]
        public async Task<IActionResult> BookFlight2([FromBody] Flight flight)
        {
            // Access the CompensationSpan instance from the ActionFilter
            var compensationSpan = HttpContext.Items["CompensationSpan"] as CompensationSpan;

            // Try to book a flight
            throw new Exception("Can´t book a flight!");

            return Ok();
        }
    }
}
