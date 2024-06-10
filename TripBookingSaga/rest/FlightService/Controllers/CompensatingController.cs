using FlowDance.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompensatingController : ControllerBase
    {
        [HttpPost("compensate")]
        public ActionResult Compensate([FromBody] IList<SpanCompensationData> compensationData)
        {
            return Ok();
        }
    }
}
