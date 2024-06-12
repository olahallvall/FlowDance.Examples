using FlightService.Models;
using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5075/api/Compensating/compensate"), Guid.Parse(correlationId), _loggerFactory))
            {

                throw new Exception("Can´t book a flight!");

                compSpan.Complete();
            }

            return Ok();

        }
    }
}
