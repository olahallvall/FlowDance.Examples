using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HotelService.Services
{
    public class FlightService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoggerFactory _iloggerFactory;

        public FlightService(IHttpClientFactory httpClientFactory, ILoggerFactory iloggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _iloggerFactory = iloggerFactory;
        }

        public void BookFlight(string passportNumber, Guid traceId)
        {
            using (var compSpan = new CompensationSpan(new HttpCompensatingAction("http://localhost:5075/api/Compensating/compensate"), traceId, _iloggerFactory))
            {
                var httpClient = _httpClientFactory.CreateClient();

                throw new Exception("No flight available!");

                compSpan.Complete();
            }
        }
    }
}
