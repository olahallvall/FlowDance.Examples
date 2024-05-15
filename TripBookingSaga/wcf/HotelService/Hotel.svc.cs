using FlowDance.Client;
using FlowDance.Common.CompensatingActions;
using Microsoft.Extensions.Logging;
using System;

namespace FlowDance.Examples.TripBookingSaga.HotelService
{
    public class Hotel : IHotel
    {
        public void BookHotel(string passportNumber, Guid traceId)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            using (var compSpanRoot = new CompensationSpan(new HttpCompensatingAction("http://localhost:55121/Compensating.svc/Compensate"), traceId, loggerFactory))
            {
                var svr = new FlightService.FlightClient();
                svr.BookFlight(passportNumber, traceId);

                compSpanRoot.Complete();
            }
        }
    }
}
