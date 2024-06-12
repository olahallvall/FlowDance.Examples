using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILoggerFactory _iloggerFactory;

        public CarController(ILoggerFactory iloggerFactory)
        {
            _iloggerFactory = iloggerFactory;
        }

        [HttpPost("bookcar")]
        public async Task<IActionResult> BookCar([FromBody] Car car)
        {
            var success = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            if (!success) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5043/api/Compensating/compensate"), Guid.Parse(correlationId), _iloggerFactory))
            {
             

                compSpan.Complete();
            }

            return Ok();
        }
    }
}
