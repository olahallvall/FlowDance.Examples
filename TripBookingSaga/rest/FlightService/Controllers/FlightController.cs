using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightService.Controllers
{
    public class FlightController : ControllerBase
    {

        private readonly ILoggerFactory _iloggerFactory;

        public FlightController(ILoggerFactory iloggerFactory)
        {
            _iloggerFactory = iloggerFactory;
        }

        [HttpPost("bookflight")]
        public async Task<IActionResult> BookFlight([FromBody] Flight flight)
        {
            var success = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            if (!success) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5113/api/Compensating/compensate"), Guid.Parse(correlationId), _iloggerFactory))
            {


                compSpan.Complete();
            }

            return Ok();

        }
    }
}
