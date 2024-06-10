using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelService.Controllers
{
    public class HotelController : ControllerBase
    {
        private readonly ILoggerFactory _iloggerFactory;

        public HotelController(ILoggerFactory iloggerFactory)
        {
            _iloggerFactory = iloggerFactory;
        }

        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel([FromBody] Hotel hotel)
        {
            var success = Request.Headers.TryGetValue("x-correlation-id", out var correlationId);
            if (!success) return BadRequest();

            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5075/api/Compensating/compensate"), Guid.Parse(correlationId), _iloggerFactory))
            {
              

                compSpan.Complete();
            }

            return Ok();
        }
    }
}
